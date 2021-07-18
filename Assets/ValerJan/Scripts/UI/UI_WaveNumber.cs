using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_WaveNumber : MonoBehaviour
{
    int _waveNumber = 1, _waveCount;
    Text _text;

    void Start()
    {
        var eh = EventHolder.Singleton;
        eh.PlanetLoaded += initiateAfterPlanet;        
        eh.CompleteWave += showCurrentWave;
        eh.EndGame += endGame;
    }

    void showCurrentWave()
    {
        _waveNumber++;
        _text.text = _waveNumber + "/" + _waveCount;
    }

    void initiateAfterPlanet(Planet planet)
    {
        _waveCount = planet.PlanetaryWaves.Waves.Length;
        _text = GetComponent<Text>();

        _text.text = _waveNumber + "/" + _waveCount;
    }

    void endGame(bool victory)
    {
        _text.text = "";
    }
}
