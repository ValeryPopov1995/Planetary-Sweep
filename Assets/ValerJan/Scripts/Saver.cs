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
        
        loadFromFile();
    }
    
    public void SaveScriptableSettings() // from ui to scriptable
    {
        if (_gameSettings.VolumeEffects != _effects.value)      _gameSettings.VolumeEffects = _effects.value;
        if (_gameSettings.VolumeMusic != _music.value)          _gameSettings.VolumeMusic = _music.value;
        if (_gameSettings.Sensetivity != _sensetivity.value)    _gameSettings.Sensetivity = _sensetivity.value;
        
        applyToMixer();
    }

    void loadScriptableSettings() // from scriptable to ui
    {
        float[] sets = {_gameSettings.VolumeEffects, _gameSettings.VolumeMusic, _gameSettings.Sensetivity};
        
        _effects.value =        sets[0];
        _music.value =          sets[1];
        _sensetivity.value =    sets[2];

        applyToMixer();
    }

    public void SaveToFile() // from scriptable to player prefs
    {
        string purs = JsonUtility.ToJson(Settings.Singleton.Purchases);
        PlayerPrefs.SetString("purchases", purs);
        string sets = JsonUtility.ToJson(Settings.Singleton.GameSettings);
        PlayerPrefs.SetString("settings", sets);

        Debug.Log("saved json sets : " + sets);
    }

    public void loadFromFile() // from player prefs to scriptable
    {
        if (!PlayerPrefs.HasKey("purchases"))
        {
            PlayerPrefs.DeleteAll();
            ResetProgress();
            return;
        }

        string purs = PlayerPrefs.GetString("purchases");
        //Settings.Singleton.Purchases = JsonUtility.FromJson<PurchasesConfig>(purs);
        JsonUtility.FromJsonOverwrite(purs, Settings.Singleton.Purchases);
        string sets = PlayerPrefs.GetString("settings");
        //Settings.Singleton.GameSettings = JsonUtility.FromJson<GameSettingsConfig>(sets);
        JsonUtility.FromJsonOverwrite(sets, Settings.Singleton.GameSettings);

        Debug.Log("load json sets : " + sets);
        loadScriptableSettings();
    }

    public void ResetProgress()
    {
        var pur = Settings.Singleton.Purchases;

        pur.Cash = 0;
        foreach(PurchaseConfig p in pur.Purchases) p.ResetLevel();
        SaveToFile();
    }

    void applyToMixer()
    {
        _mixer.SetFloat("effects",    _gameSettings.VolumeEffects);
        _mixer.SetFloat("music",      _gameSettings.VolumeMusic);
    }
}