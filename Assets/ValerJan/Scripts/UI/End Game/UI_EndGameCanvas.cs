using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EndGameCanvas : MonoBehaviour
{
    void Awake() // TODO check
    {
        EventHolder.Singleton.EndGame += endGame;
        //gameObject.SetActive(false);
    }

    void endGame(bool victory)
    {
        gameObject.SetActive(true);
    }
}
