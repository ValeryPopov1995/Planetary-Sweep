using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EndGameCanvas : MonoBehaviour
{
    void Start()
    {
        EventHolder.Singleton.EndGame += endGame;
        //Debug.Log("EndGame canvas subscribed to EndGame Action<bool>");
        gameObject.SetActive(false);
    }

    void endGame(bool victory)
    {
        gameObject.SetActive(true);
    }
}
