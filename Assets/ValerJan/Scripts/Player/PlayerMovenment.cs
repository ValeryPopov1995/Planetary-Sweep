using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovenment : MonoBehaviour
{
    public Transform Body;

    int jetpackSpeedOut = 10;
    float cameraVerticalAngle, jumpPositiveAddGravity, lastTimeJetpack;

    Rigidbody rb;
    InputSystem input;
    Settings sets;
    Transform cam;

    void Start()
    {
        EventHolder.Singlton.UseJetPack += jetpack;

        rb = Body.GetComponent<Rigidbody>();
        input = InputSystem.Singleton;
        sets = Settings.Singleton;
        cam = Camera.main.transform;
    }

    void Update()
    {
        #region  rotate
        Vector2 mouseDelta = input.EyeTrigger.GetDelta();
        Body.Rotate(Vector3.up * mouseDelta.x * sets.PlayerSets.Sensetivity * Time.deltaTime);
        cameraVerticalAngle -= mouseDelta.y * sets.PlayerSets.Sensetivity * Time.deltaTime;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -60, 60);
        cam.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
        #endregion
    }

    void FixedUpdate()
    {
        #region movenment
        if (jumpPositiveAddGravity > 0) jumpPositiveAddGravity -= jetpackSpeedOut;

        Vector3 moveInput = Body.right * input.MoveStick.Horizontal + Body.forward * input.MoveStick.Vertical;
        
        rb.velocity = moveInput * sets.PlayerSets.Speed;
        rb.velocity += Body.up * (jumpPositiveAddGravity - Settings.Singleton.GamePlaySets.Gravity);
        rb.velocity *= Time.fixedDeltaTime;
        #endregion
    }

    void jetpack(System.Object obj)
    {
        if (Time.time < sets.PlayerSets.JetpackCullback + lastTimeJetpack) return;
        lastTimeJetpack = Time.time;

        jumpPositiveAddGravity = sets.PlayerSets.JetpackForce;
    }
}
