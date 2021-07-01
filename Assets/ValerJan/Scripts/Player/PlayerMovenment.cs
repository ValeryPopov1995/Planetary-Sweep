using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovenment : MonoBehaviour
{
    public Transform Body;

    int _jetpackPositiveGravityFade = 10;
    float _cameraVerticalAngle, _jumpPositiveAddGravity, _lastJetpackTime, _sensetivity, _gravity, _speed, _jetpackCulldown, _jetForce;

    Rigidbody _rigidbody;
    InputSystem _input;
    Transform _camera;

    void Start()
    {
        EventHolder.Singlton.UseJetPack += jetpack;

        _rigidbody = Body.GetComponent<Rigidbody>();
        _input = InputSystem.Singleton;
        _camera = Camera.main.transform;

        var sets = Settings.Singleton;
        _sensetivity = sets.GameSettings.Sensetivity;
        _gravity = sets.GameBalance.Gravity;
        _speed = sets.Purchases.PlayerSpeed.CurrentValue;
        _jetpackCulldown = sets.Purchases.JetpackCulldown.CurrentValue;
        _jetForce = sets.Purchases.JetpackForce.CurrentValue;
    }

    void Update()
    {
        #region  rotate
        Vector2 mouseDelta = _input.EyeTrigger.GetDelta();
        Body.Rotate(Vector3.up * mouseDelta.x * _sensetivity * Time.deltaTime);
        _cameraVerticalAngle -= mouseDelta.y * _sensetivity * Time.deltaTime;
        _cameraVerticalAngle = Mathf.Clamp(_cameraVerticalAngle, -60, 60);
        _camera.localEulerAngles = new Vector3(_cameraVerticalAngle, 0, 0);
        #endregion
    }

    void FixedUpdate()
    {
        #region movenment
        if (_jumpPositiveAddGravity > 0) _jumpPositiveAddGravity -= _jetpackPositiveGravityFade;

        Vector3 moveInput = Body.right * _input.MoveStick.Horizontal + Body.forward * _input.MoveStick.Vertical;
        
        _rigidbody.velocity = moveInput * _speed;
        _rigidbody.velocity += Body.up * (_jumpPositiveAddGravity - _gravity);
        _rigidbody.velocity *= Time.fixedDeltaTime;
        #endregion
    }

    void jetpack()
    {
        if (Time.time < _jetpackCulldown + _lastJetpackTime) return;
        _lastJetpackTime = Time.time;

        _jumpPositiveAddGravity = _jetForce;
    }
}
