using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    float health;

    void Start()
    {
        health = Settings.Singleton.PlayerSets.Health;
        EventHolder.Singlton.PlayerChangeHealth += takeDamage;

        transform.position = FindObjectOfType<Planet>().StartPlayerPosition.position;
    }

    void takeDamage(System.Object damage)
    {
        health -= (float)damage;
        if (health <= 0) die();
    }

    void die()
    {
        EventHolder.Singlton.DefeatGame?.Invoke(null);
    }
}
