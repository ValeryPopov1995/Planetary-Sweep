using UnityEngine;
using UnityEngine.UI;

public class Award : MonoBehaviour
{
    [SerializeField] Text _textAwardKill, _textTimeBonus, _textDefeatCoef;
    [SerializeField] int _secondsAward = 300; // every second of game decriese timeBonus (see getAward method)
    int _awardKill, _awardTimeBonus;

    float _startLevelTime;

    void Start()
    {
        var holder = EventHolder.Singleton;
        holder.AwardForKill += addAward;
        holder.EndGame += getAward;

        _startLevelTime = Time.time;
    }

    public void AdvertisementAward()
    {
        Settings.Singleton.Purchases.Cash += _awardKill;
        showAward(true); // TODO
    }

    void addAward(int value)
    {
        if (value <= 0) Debug.LogError("award add value <= 0");

        _awardKill += value;
    }

    void getAward(bool victory) // TODO award for PlanetHealth
    {
        var sets = Settings.Singleton;

        int gameTime = (int)(Time.time - _startLevelTime);
        int timeBonus = _secondsAward - gameTime;
        if (timeBonus > 0) _awardTimeBonus = timeBonus;

        if (!victory) _awardKill = (int)(_awardKill * sets.GameBalance.DefeatAwardCoeficient);
        sets.Purchases.Cash += _awardKill;
        
        showAward(victory);
    }

    void showAward(bool victory)
    {
        _textAwardKill.text = "+ " + _awardKill;
        _textTimeBonus.text = "+ " + _awardTimeBonus;
        if (victory) _textDefeatCoef.text = "победа!";
        else _textDefeatCoef.text = "/2 - поражение";
    }
}
