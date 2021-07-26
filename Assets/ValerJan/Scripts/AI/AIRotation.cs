using UnityEngine;

[AddComponentMenu("AI Enemy/AI Rotation")]
public class AIRotation : AIScaning
{
    [Min(.1f)] [SerializeField] float _speed = 40;
    [SerializeField] bool _rotateToPlanet = true;

    void Update()
    {
        if (_rotateToPlanet) GravityBody.RotateToPlanet(transform);
        
        if (Scaner.Target == null) return;

        Vector3 toTarget = (Scaner.Target.position - transform.position).normalized;
        var look = Quaternion.LookRotation(toTarget, transform.up);
        var toward = Quaternion.RotateTowards(transform.rotation, look, _speed * Time.deltaTime);
        toward.x = transform.rotation.x;
        toward.z = transform.rotation.z;
        transform.rotation = toward;
    }
}
