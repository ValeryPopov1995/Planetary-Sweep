using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UI_WaveProgress : MonoBehaviour
{
    Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();

        var holder = EventHolder.Singleton;

        holder.CompleteWave += resetBar;
        holder.ChangeEnemyCount += updateBar;
    }

    void updateBar(int count)
    {
        if (count > 0) _slider.maxValue++;
        else _slider.value++;
    }

    void resetBar()
    {
        _slider.value = 0;
        _slider.maxValue = 0;
    }
}
