using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) EventHolder.Singleton.EndGame?.Invoke(true);
        if (Input.GetKeyDown(KeyCode.P)) PlayerPrefs.DeleteAll();
    }
}
