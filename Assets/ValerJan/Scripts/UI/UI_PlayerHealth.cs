using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerHealth _player;
    Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        EventHolder.Singleton.PlayerChangeHealth += showHealth;
    }

    void showHealth(float damage)
    {
        _text.text = _player.Health + "hp";
    }
}
