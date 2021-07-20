using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ExitToMenu()
    {
        EventHolder.Singleton.PauseGame?.Invoke(false);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
    public void ExitGame() { Application.Quit(); }
    public void PauseGame(bool pause) { EventHolder.Singleton.PauseGame?.Invoke(pause); }

    void hideInput(bool victory)
    {
        MoveStick.gameObject.SetActive(false); // TODO check work
        MoveStick.enabled = false;
        EyeTrigger.enabled = false;
    }
}