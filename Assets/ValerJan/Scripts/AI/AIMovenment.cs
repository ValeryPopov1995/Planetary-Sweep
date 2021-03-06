using UnityEngine;

[AddComponentMenu("AI Enemy/AI Movenment")]
[RequireComponent(typeof(Rigidbody))]
public class AIMovenment : AIScaning
{
    [Min(.1f)] [SerializeField] float _speed = 500, _followDistance = 5;
    [SerializeField] Animator _controller;

    Rigidbody _rigid;

    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _rigid.useGravity = false;
        _rigid.freezeRotation = true;
    }
    
    void FixedUpdate()
    {
        Vector3 gravity = -transform.up * Settings.Singleton.GameBalance.Gravity * Time.fixedDeltaTime;
        _rigid.MovePosition(transform.position + gravity);
        if (_controller != null) _controller.SetFloat("speed", 0);

        if (Scaner.Target == null) return;
        float dis = Vector3.Distance(transform.position, Scaner.Target.position);
        if (dis < _followDistance) return;

        Vector3 moveVector = Vector3.zero;
        moveVector = transform.forward * _speed;
        moveVector *= Time.fixedDeltaTime;
        _rigid.MovePosition(transform.position + moveVector);
        if (_controller != null) _controller.SetFloat("speed", 1);
    }
}
