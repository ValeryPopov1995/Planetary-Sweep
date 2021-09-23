using UnityEngine;

[AddComponentMenu("AI Enemy/AI Scaner")]
[RequireComponent(typeof(SphereCollider))]
public class AIScaner : MonoBehaviour
{
    public enum TargetPriority {player, building}

    [SerializeField] TargetPriority _priority = TargetPriority.building;
    [Min(.1f)] [SerializeField] float _radius = 10;

    Transform _target;
    public Transform Target
    {
        get {return _target;}
        private set
        {
            _target = value;
            Debug.Log("AI Scaner: new target - " + value.name);
        }
    }

    void Awake()
    {
        var sp = GetComponent<SphereCollider>();
        sp.isTrigger = true;
        sp.radius = _radius;

        if (_priority == TargetPriority.player) Target = GameObject.FindWithTag("Player").transform;
        else findBuilding();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_priority == TargetPriority.player) return;
        if (other.CompareTag("Player")) Target = other.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        if (_priority == TargetPriority.player) return;
        if (other.CompareTag("Player")) findBuilding();
    }

    private void findBuilding() => Target = GameObject.FindWithTag("Planetary Object").transform;
}
