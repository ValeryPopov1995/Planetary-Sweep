using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using System;

public class Saver : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _effects, _music, _sensetivity;
    GameSettingsConfig _gameSettings;
    string _path;

    void Start()
    {
        _path = Application.persistentDataPath + "/data.ps";
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
        string levels = "";
        for (int i = 0; i < Settings.Singleton.Purchases.Purchases.Length; i++)
            levels += Settings.Singleton.Purchases.Purchases[i].Level + " ";
        Debug.Log("levels are saved :" + levels);
        levels.Trim();

        string sets = JsonUtility.ToJson(Settings.Singleton.GameSettings);
        
        //File.WriteAllLines(_path, new string[] {levels, sets} );
        PlayerPrefs.SetInt("cash", Settings.Singleton.Purchases.Cash);
        PlayerPrefs.SetString("lvls", levels);
        PlayerPrefs.SetString("sets", sets);

        Debug.Log("save path : " + _path);
    }

    public void loadFromFile() // from player prefs to scriptable
    {
        try
        {
            string lvls = PlayerPrefs.GetString("lvls");
            string sets = PlayerPrefs.GetString("sets");

            Settings.Singleton.Purchases.Cash = PlayerPrefs.GetInt("cash");
            string[] levels = lvls.Split(' ');
            for (int i = 0; i < Settings.Singleton.Purchases.Purchases.Length; i++) Settings.Singleton.Purchases.Purchases[i].Level = Convert.ToInt32(levels[i]);
            JsonUtility.FromJsonOverwrite(sets, Settings.Singleton.GameSettings);

            loadScriptableSettings();
        }
        catch
        {
            ResetProgress();
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        var pur = Settings.Singleton.Purchases;

        pur.Cash = 10000;
        foreach(PurchaseConfig p in pur.Purchases) p.ResetLevel();
        SaveToFile();

        Debug.Log("progress reset");
    }

    void applyToMixer()
    {
        _mixer.SetFloat("effects",    _gameSettings.VolumeEffects);
        _mixer.SetFloat("music",      _gameSettings.VolumeMusic);
    }
}

/* not work
    string purs = JsonUtility.ToJson(Settings.Singleton.Purchases);
    PlayerPrefs.SetString("purchases", purs);

    //PlayerPrefs.SetString("settings", sets);
    //PlayerPrefs.Save();

    //if (!PlayerPrefs.HasKey("purchases") || !PlayerPrefs.HasKey("settings")) return;

    
    //string purs = PlayerPrefs.GetString("purchases");
    //Settings.Singleton.Purchases = JsonUtility.FromJson<PurchasesConfig>(purs);
    //JsonUtility.FromJsonOverwrite(lines[0], Settings.Singleton.Purchases);

    //string sets = PlayerPrefs.GetString("settings");
    //Settings.Singleton.GameSettings = JsonUtility.FromJson<GameSettingsConfig>(sets);

    //Debug.Log("lvls.lemgth = " + lvls.Length + ", purs.length = " + Settings.Singleton.Purchases.Purchases.Length); // 16 vs 15
*/
