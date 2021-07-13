using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _effects, _music;
    [SerializeField] Dropdown _fpsDropdown;
    GameSettingsConfig _gameSettings;

    void Start()
    {
        _gameSettings = Settings.Singleton.GameSettings;

        _effects.value = _gameSettings.VolumeEffects;
        _music.value = _gameSettings.VolumeMusic;
        _fpsDropdown.value = _gameSettings.DropdownFPS;
        
        applySettings();
    }
    
    public void SaveSettings()
    {
        if (_gameSettings.VolumeEffects != _effects.value) _gameSettings.VolumeEffects = _effects.value;
        if (_gameSettings.VolumeMusic != _music.value) _gameSettings.VolumeMusic = _music.value;
        if (_gameSettings.DropdownFPS != _fpsDropdown.value) _gameSettings.DropdownFPS = _fpsDropdown.value;

        applySettings();
    }

    public void ResetProgress()
    {
        var pur = Settings.Singleton.Purchases;

        pur.Cash = 0;
        foreach(PurchaseConfig p in pur.Purchases) p.ResetLevel();
    }

    void applySettings()
    {
        _mixer.SetFloat("effects", _gameSettings.VolumeEffects);
        _mixer.SetFloat("music", _gameSettings.VolumeMusic);
        Application.targetFrameRate = _gameSettings.DropdownFPS * 30;
    }
}
