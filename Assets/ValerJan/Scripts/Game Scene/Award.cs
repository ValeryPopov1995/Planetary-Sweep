using UnityEngine;
using UnityEngine.UI;

public class Award : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] int _secondsAward = 300; // every second of game decriese timeBonus (see getAward method)
    int _award;

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
        Settings.Singleton.Purchases.Cash += _award;
        showAward();
    }

    void addAward(int value)
    {
        if (value <= 0) Debug.LogError("award add value <= 0");

        _award += value;
    }

    void getAward(bool victory) // TODO award for PlanetHealth
    {
        var sets = Settings.Singleton;

        int gameTime = (int)(Time.time - _startLevelTime);
        int timeBonus = _secondsAward - gameTime;
        if (timeBonus > 0) _award += timeBonus;

        if (!victory) _award = (int)(_award * sets.GameBalance.DefeatAwardCoeficient);
        sets.Purchases.Cash += _award;
        showAward();
    }

    void showAward()
    {
        if (_text == null) return;

        _text.text = "+ " +_award;
    }
}
