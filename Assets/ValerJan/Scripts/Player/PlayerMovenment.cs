using UnityEngine;

public class PlayerMovenment : MonoBehaviour
{
    [SerializeField] Transform _body;
    [SerializeField] GravityBody _gravityBody;
    [SerializeField] PurchaseConfig _playerSpeed, _jetpackForce, _jetpackCulldown;

    int _jetpackPositiveGravityFade = 10;
    float _cameraVerticalAngle, _jumpPositiveAddGravity, _lastJetpackTime, _sensetivity, _gravity;

    Rigidbody _rigidbody;
    InputSystem _input;
    Transform _camera;

    void Start()
    {
        EventHolder.Singleton.UseJetPack += jetpack;

        _rigidbody = _body.GetComponent<Rigidbody>();
        _input = InputSystem.Singleton;
        _camera = Camera.main.transform;

        var sets = Settings.Singleton;
        _sensetivity = sets.GameSettings.Sensetivity;
        _gravity = sets.GameBalance.Gravity;
    }

    void Update()
    {
        #region  rotate
        _gravityBody.RotateToPlanet();
        Vector2 mouseDelta = _input.EyeTrigger.GetDelta();
        _body.Rotate(Vector3.up * mouseDelta.x * _sensetivity * Time.deltaTime);
        _cameraVerticalAngle -= mouseDelta.y * _sensetivity * Time.deltaTime;
        _cameraVerticalAngle = Mathf.Clamp(_cameraVerticalAngle, -60, 60);
        _camera.localEulerAngles = new Vector3(_cameraVerticalAngle, 0, 0);
        #endregion
    }

    void FixedUpdate()
    {
        #region movenment
        if (_jumpPositiveAddGravity > 0) _jumpPositiveAddGravity -= _jetpackPositiveGravityFade;

        Vector3 moveInput = _body.right * _input.MoveStick.Horizontal + _body.forward * _input.MoveStick.Vertical;
        
        _rigidbody.velocity = moveInput * _playerSpeed.Value;
        _rigidbody.velocity += _body.up * (_jumpPositiveAddGravity - _gravity);
        _rigidbody.velocity *= Time.fixedDeltaTime;
        #endregion
    }

    void jetpack()
    {
        if (Time.time < _jetpackCulldown.Value + _lastJetpackTime) return;
        _lastJetpackTime = Time.time;

        _jumpPositiveAddGravity = _jetpackForce.Value;
    }
}
