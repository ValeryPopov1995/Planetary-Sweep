using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    [SerializeField] PurchaseConfig playerHealth;
    float _health;

    void Start()
    {
        EventHolder.Singlton.PlanetLoaded += setStartPosition;
        _health = playerHealth.Value;
        EventHolder.Singlton.PlayerChangeHealth += takeDamage;
    }

    void takeDamage(float damage)
    {
        _health -= (float)damage;
        if (_health <= 0) die();
    }

    void die()
    {
        EventHolder.Singlton.DefeatGame?.Invoke();
    }

    void setStartPosition(Planet planet)
    {
        transform.position = planet.StartPlayerPosition.position;
    }
}
