using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_LevelCard : MonoBehaviour
{
    [SerializeField] GameObject planetPrefab;

    public void LoadPlanet()
    {
        Settings.Singleton.GameSettings.LoadingPlanet = planetPrefab;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
}
