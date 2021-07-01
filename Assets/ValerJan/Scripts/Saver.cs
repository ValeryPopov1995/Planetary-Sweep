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
        var def = Settings.Singleton.DefaultPurchases;

        pur.ShotgunDamage.CurrentLevel = def.ShotgunDamage.CurrentLevel; // TODO как иначе?!
        pur.ShotgunCulldown.CurrentLevel = def.ShotgunCulldown.CurrentLevel;
        pur.ShotgunMaxCount.CurrentLevel = def.ShotgunMaxCount.CurrentLevel;

        pur.RocketDamage.CurrentLevel = def.RocketDamage.CurrentLevel;
        pur.RocketSplashRadius.CurrentLevel = def.RocketSplashRadius.CurrentLevel;
        pur.RocketMaxCount.CurrentLevel = def.RocketMaxCount.CurrentLevel;

        pur.AutorifleDamage.CurrentLevel = def.AutorifleDamage.CurrentLevel;
        pur.AutorifleCulldown.CurrentLevel = def.AutorifleCulldown.CurrentLevel;

        pur.PlayerHealth.CurrentLevel = def.PlayerHealth.CurrentLevel;
        pur.PlayerSpeed.CurrentLevel = def.PlayerSpeed.CurrentLevel;

        pur.JetpackForce.CurrentLevel = def.JetpackForce.CurrentLevel;
        pur.JetpackCulldown.CurrentLevel = def.JetpackCulldown.CurrentLevel;
    }

    void applySettings()
    {
        _mixer.SetFloat("effects", _gameSettings.VolumeEffects);
        _mixer.SetFloat("music", _gameSettings.VolumeMusic);
        Application.targetFrameRate = _gameSettings.DropdownFPS * 30;
    }
}
