using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

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
        string purs = JsonUtility.ToJson(Settings.Singleton.Purchases);
        //PlayerPrefs.SetString("purchases", purs);

        string sets = JsonUtility.ToJson(Settings.Singleton.GameSettings);
        //PlayerPrefs.SetString("settings", sets);
        //PlayerPrefs.Save();

        File.WriteAllLines(_path, new string[] {purs, sets} );

        Debug.Log("save path : " + _path);
    }

    public void loadFromFile() // from player prefs to scriptable
    {
        //if (!PlayerPrefs.HasKey("purchases") || !PlayerPrefs.HasKey("settings")) return;
        if (!File.Exists(_path))
        {
            ResetProgress();
            return;
        }

        var lines = File.ReadAllLines(_path);
        //string purs = PlayerPrefs.GetString("purchases");
        //Settings.Singleton.Purchases = JsonUtility.FromJson<PurchasesConfig>(purs);
        JsonUtility.FromJsonOverwrite(lines[0], Settings.Singleton.Purchases);

        //string sets = PlayerPrefs.GetString("settings");
        //Settings.Singleton.GameSettings = JsonUtility.FromJson<GameSettingsConfig>(sets);
        JsonUtility.FromJsonOverwrite(lines[1], Settings.Singleton.GameSettings);

        Debug.Log("load json purs : " + lines[0]);
        loadScriptableSettings();
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