using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovenment : MonoBehaviour
{
    public Transform Body;

    int jetpackSpeedOut = 10;
    float cameraVerticalAngle, jumpPositiveAddGravity, lastTimeJetpack, sensetivity, gravity, speed, jetCD, jetForce;

    Rigidbody rb;
    InputSystem input;
    Transform cam;

    void Start()
    {
        EventHolder.Singlton.UseJetPack += jetpack;

        rb = Body.GetComponent<Rigidbody>();
        input = InputSystem.Singleton;
        cam = Camera.main.transform;

        var sets = Settings.Singleton;
        sensetivity = sets.GamePlaySets.Sensetivity;
        gravity = sets.GamePlaySets.Gravity;
        speed = sets.Purchases.PlayerSpeed.CurrentValue;
        jetCD = sets.Purchases.JetpackCulldown.CurrentValue;
        jetForce = sets.Purchases.JetpackForce.CurrentValue;
    }

    void Update()
    {
        #region  rotate
        Vector2 mouseDelta = input.EyeTrigger.GetDelta();
        Body.Rotate(Vector3.up * mouseDelta.x * sensetivity * Time.deltaTime);
        cameraVerticalAngle -= mouseDelta.y * sensetivity * Time.deltaTime;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -60, 60);
        cam.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
        #endregion
    }

    void FixedUpdate()
    {
        #region movenment
        if (jumpPositiveAddGravity > 0) jumpPositiveAddGravity -= jetpackSpeedOut;

        Vector3 moveInput = Body.right * input.MoveStick.Horizontal + Body.forward * input.MoveStick.Vertical;
        
        rb.velocity = moveInput * speed;
        rb.velocity += Body.up * (jumpPositiveAddGravity - gravity);
        rb.velocity *= Time.fixedDeltaTime;
        #endregion
    }

    void jetpack()
    {
        if (Time.time < jetCD + lastTimeJetpack) return;
        lastTimeJetpack = Time.time;

        jumpPositiveAddGravity = jetForce;
    }
}
