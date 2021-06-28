using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_Massage : MonoBehaviour
{
    Text txt;
    Color startColor;

    void Start()
    {
        txt = GetComponent<Text>();
        startColor = txt.color;
        EventHolder.Singlton.Massage += showMassage;

        StartCoroutine(animate());
    }

    void showMassage(System.Object obj)
    {
        txt.text = (string)obj;
        StopAllCoroutines();
        StartCoroutine(animate()); // TODO animation
    }

    IEnumerator animate() // temporary sln
    {
        Color c = startColor;
        c.a = 0;
        for (int i = 0; i < 10; i++)
        {
            c.a += .1f;
            txt.color = c;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 10; i++)
        {
            c.a -= .1f;
            txt.color = c;
            yield return new WaitForEndOfFrame();
        }
    }
}
