using UnityEngine;
using UnityEngine.UI;

public class Award : MonoBehaviour
{
    [SerializeField] Text _text;
    int _award;

    void Start()
    {
        var holder = EventHolder.Singleton;
        holder.AwardForKill += addAward;
        holder.EndGame += getAward;
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

    void getAward(bool victory)
    {
        var sets = Settings.Singleton;

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
