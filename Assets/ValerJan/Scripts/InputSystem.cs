using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSystem : MonoBehaviour
{
    public Joystick MoveStick;
    public ShooterEventTrigger EyeTrigger;
    [Space]
    public List<Canvas> CanvasesToHide;

    public static InputSystem Singleton;

    void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Button_Rocket() { EventHolder.Singlton.UseRocket?.Invoke(); }
    public void Button_Granate() { EventHolder.Singlton.UseGranate?.Invoke(); }
    public void Button_Shotgun() { EventHolder.Singlton.UseShotgun?.Invoke(); }
    public void Button_JetPack() { EventHolder.Singlton.UseJetPack?.Invoke(); }

    public void Button_HideCanvases()
    {
        foreach(var e in CanvasesToHide) e.gameObject.SetActive(false);
    }
}
