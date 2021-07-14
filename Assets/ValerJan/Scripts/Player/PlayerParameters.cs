using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    [SerializeField] PurchaseConfig _playerHealth;
    float _health;

    void Start()
    {
        EventHolder.Singleton.PlanetLoaded += setStartPosition;
        _health = _playerHealth.Value;
        EventHolder.Singleton.PlayerChangeHealth += changeHealth;
    }

    void changeHealth(float value)
    {
        _health += value;
        if (_health <= 0) die();
        else if (_health > _playerHealth.Value) _health = _playerHealth.Value;
    }

    void die()
    {
        Debug.Log("Defeat : player die");
        EventHolder.Singleton.EndGame?.Invoke(false);
    }

    void setStartPosition(Planet planet)
    {
        transform.position = planet.StartPlayerPosition.position;
    }
}
