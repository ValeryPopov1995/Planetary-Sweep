using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] GameConfig DefaultGameConfig, CurrentGameConfig;

    void Start()
    {
        SaveData();
    }
    
    public void SaveData()
    {
        // it is work ! CurrentGameConfig.Gravity = 500;
    }

    public Data LoadData()
    {
        return new Data();
    }
}

public class Data
{

}
