using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_EndGameText : MonoBehaviour
{
    [SerializeField] string _victoryText, _defeatText;
    Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        EventHolder.Singleton.EndGame += endGame;
    }

    void endGame(bool victory)
    {
        if (victory) _text.text = _victoryText;
        else _text.text = _defeatText;
    }
}
