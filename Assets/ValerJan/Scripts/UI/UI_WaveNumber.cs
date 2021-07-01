using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_WaveNumber : MonoBehaviour
{
    int _waveNumber = 1, _waveCount;
    Text _text;

    void Start()
    {
        _waveCount = FindObjectOfType<Planet>().PlanetaryWaves.Waves.Length;
        _text = GetComponent<Text>();

        _text.text = _waveNumber + "/" + _waveCount;
        
        EventHolder.Singlton.CompleteWave += showWaveNumber;
    }

    void showWaveNumber()
    {
        _waveNumber++;
        if (_waveNumber > _waveCount)
        {
            EventHolder.Singlton.VictoryGame();
            _text.text = "";
        }
        else _text.text = _waveNumber + "/" + _waveCount;
    }
}
