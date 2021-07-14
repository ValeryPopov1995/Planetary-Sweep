using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Joystick MoveStick;
    public ShooterEventTrigger EyeTrigger;

    public static InputSystem Singleton;

    void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this);
    }

    void Start()
    {
        if (EventHolder.Singleton != null) EventHolder.Singleton.EndGame += hideInput;
    }

    void Update() // TODO delete
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("test init victory");
            EventHolder.Singleton.EndGame?.Invoke(true);
        }
    }

    public void ExitGame() { Application.Quit(); }

    public void Button_Rocket() { EventHolder.Singleton.UseRocket?.Invoke(); }
    public void Button_Granate() { EventHolder.Singleton.UseGranate?.Invoke(); }
    public void Button_Shotgun() { EventHolder.Singleton.UseShotgun?.Invoke(); }
    public void Button_JetPack() { EventHolder.Singleton.UseJetPack?.Invoke(); }

    void hideInput(bool victory)
    {
        MoveStick.enabled = false;
        EyeTrigger.enabled = false;
    }
}