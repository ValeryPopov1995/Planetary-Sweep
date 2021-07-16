using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Unity.Collections;
using UnityEngine.UI;

public class UI_LevelCard : MonoBehaviour
{
    [SerializeField] GameObject _planetPrefab;
    [SerializeField] Button _playButton;
    [SerializeField] Requirement[] _requirements;

    void OnEnable() // update interactable play button
    {
        if (_requirements.Length == 0) return;

        bool interact = true;
        foreach(var r in _requirements)
        {
            if (r.Purchase.Level < r.ReqLevel)
            {
                interact = false;
                break;
            }
        }
        if (_playButton.interactable != interact) _playButton.interactable = interact;
    }

    public void LoadPlanet()
    {
        Settings.Singleton.GameSettings.LoadingPlanet = _planetPrefab;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
}

[Serializable]
class Requirement
{
    public PurchaseConfig Purchase;
    public int ReqLevel;
}
