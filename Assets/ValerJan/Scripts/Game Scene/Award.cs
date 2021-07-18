using UnityEngine;
using UnityEngine.UI;

public class Award : MonoBehaviour
{
    [SerializeField] Text _textAwardKill, _textTimeBonus, _textAwardAds, _textAward;
    int _secondsAward; // every second of game decriese timeBonus (see getAward method)
    int _awardKill, _awardTimeBonus, _awardAdvertisment;
    int _award => _awardKill + _awardTimeBonus + _awardAdvertisment;

    float _startLevelTime;

    void Start()
    {
        var holder = EventHolder.Singleton;
        holder.AwardForKill += addKillAward;
        holder.EndGame += getAward;
        holder.PlanetLoaded += setSecondsAward;

        _startLevelTime = Time.time;
    }

    void setSecondsAward(Planet planet) => _secondsAward = planet.SecondsAward;

    public void GiveAdvertisementAward()
    {
        _awardAdvertisment = _awardKill + _awardTimeBonus;
        Settings.Singleton.Purchases.Cash += _awardAdvertisment;
        showAward();
    }

    void addKillAward(int value)
    {
        if (value <= 0) Debug.LogError("award add value <= 0");
        _awardKill += value;
    }

    void getAward(bool victory) // TODO award for PlanetHealth
    {
        var sets = Settings.Singleton;

        // time bonus
        int gameTime = (int)(Time.time - _startLevelTime);
        int timeBonus = _secondsAward - gameTime;
        if (timeBonus > 0) _awardTimeBonus = timeBonus;

        if (!victory) _awardKill = (int)(_awardKill * sets.GameBalance.DefeatAwardCoeficient);
        sets.Purchases.Cash += _awardKill + _awardTimeBonus;
        
        showAward();
    }

    void showAward()
    {
        _textAwardKill.text = "+ " + _awardKill;
        _textTimeBonus.text = "+ " + _awardTimeBonus;
        _textAwardAds.text = "+ " + _awardAdvertisment;
        _textAward.text = "+ " + _award;
    }
}
