using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_WaveNumber : MonoBehaviour
{
    int number = 1, maxWave;
    Text txt;

    void Start()
    {
        maxWave = FindObjectOfType<Planet>().PlanetaryWaves.Waves.Length;
        txt = GetComponent<Text>();

        txt.text = number + "/" + maxWave;
        EventHolder.Singlton.CompleteWave += showWaveNumber;
    }

    void showWaveNumber(System.Object obj)
    {
        number++;
        txt.text = number + "/" + maxWave;
    }

    void showVictory(System.Object obj)
    {
        txt.text = "";
    }
}
