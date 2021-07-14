using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _effects, _music, _sensetivity;
    GameSettingsConfig _gameSettings;

    void Start()
    {
        _gameSettings = Settings.Singleton.GameSettings;

        loadSettingsFromFile();
    }
    
    public void SaveSettingsToFile()
    {
        if (_gameSettings.VolumeEffects != _effects.value)      _gameSettings.VolumeEffects = _effects.value;
        if (_gameSettings.VolumeMusic != _music.value)          _gameSettings.VolumeMusic = _music.value;
        if (_gameSettings.Sensetivity != _sensetivity.value)    _gameSettings.Sensetivity = _sensetivity.value;
        
        applySettings();
    }

    public void ResetProgress()
    {
        var pur = Settings.Singleton.Purchases;

        pur.Cash = 0;
        foreach(PurchaseConfig p in pur.Purchases) p.ResetLevel();
    }

    void loadSettingsFromFile()
    {
        float[] sets = {_gameSettings.VolumeEffects, _gameSettings.VolumeMusic, _gameSettings.Sensetivity};
        
        _effects.value =        sets[0];
        _music.value =          sets[1];
        _sensetivity.value =    sets[2];

        applySettings();
    }

    void applySettings()
    {
        _mixer.SetFloat("effects",    _gameSettings.VolumeEffects);
        _mixer.SetFloat("music",      _gameSettings.VolumeMusic);
    }
}
