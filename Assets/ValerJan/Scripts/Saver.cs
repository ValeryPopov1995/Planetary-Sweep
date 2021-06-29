using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{
    [SerializeField] AudioMixer Mixer;
    [SerializeField] Slider effects, music;
    [SerializeField] Dropdown fps;

    GameSettingsConfig sets;

    void Start()
    {
        sets = Settings.Singleton.GameSettings;

        effects.value = sets.VolumeEffects;
        music.value = sets.VolumeMusic;
        fps.value = sets.DropdownFPS;
        
        applySettings();
    }
    
    public void SaveSettings()
    {
        if (sets.VolumeEffects != effects.value) sets.VolumeEffects = effects.value;
        if (sets.VolumeMusic != music.value) sets.VolumeMusic = music.value;
        if (sets.DropdownFPS != fps.value) sets.DropdownFPS = fps.value;

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
        Mixer.SetFloat("effects", sets.VolumeEffects);
        Mixer.SetFloat("music", sets.VolumeMusic);
        Application.targetFrameRate = sets.DropdownFPS * 30;
    }
}
