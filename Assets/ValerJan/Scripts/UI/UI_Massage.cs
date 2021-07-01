using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_Massage : MonoBehaviour
{
    Text _text;
    Color _startColor;

    void Start()
    {
        _text = GetComponent<Text>();
        _startColor = _text.color;
        EventHolder.Singlton.Massage += showMassage;

        StartCoroutine(animate());
    }

    void showMassage(System.Object obj)
    {
        _text.text = (string)obj;
        StopAllCoroutines();
        StartCoroutine(animate()); // TODO animation
    }

    IEnumerator animate() // temporary sln
    {
        Color c = _startColor;
        c.a = 0;
        for (int i = 0; i < 10; i++)
        {
            c.a += .1f;
            _text.color = c;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 10; i++)
        {
            c.a -= .1f;
            _text.color = c;
            yield return new WaitForEndOfFrame();
        }
    }
}
