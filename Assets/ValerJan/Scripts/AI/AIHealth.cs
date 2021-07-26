using UnityEngine;

public class AIHealth : MonoBehaviour
{
    [Min(.1f)] [SerializeField] float _health = 10;

    void Start()
    {
        tag = "Enemy";
        gameObject.layer = 3; // Enemy, for granate explosion
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0) Destroy(gameObject);
    }
}
