using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class UI_DoubleAward : MonoBehaviour
{
    Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        StartCoroutine(initAds());
    }

    public void ShowAds()
    {
        Advertisement.Show();
        gameObject.SetActive(false);
    }

    IEnumerator initAds()
    {
        //_button.interactable = false;
        Advertisement.Initialize("4217177");
        yield return new WaitForEndOfFrame();
        //while(!Advertisement.isInitialized) yield return new WaitForEndOfFrame();
        _button.interactable = true;
    }
}
