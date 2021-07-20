using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    public float Health { get; private set; }
    [SerializeField] PurchaseConfig _playerHealth;
    bool _dead => Health > 0;

    void Start()
    {
        EventHolder.Singleton.PlanetLoaded += setStartPosition;
        Health = _playerHealth.Value;
        EventHolder.Singleton.PlayerChangeHealth += changeHealth;
    }

    void changeHealth(float value)
    {
        Health += value;
        if (Health <= 0) die();
        else if (Health > _playerHealth.Value) Health = _playerHealth.Value;
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
