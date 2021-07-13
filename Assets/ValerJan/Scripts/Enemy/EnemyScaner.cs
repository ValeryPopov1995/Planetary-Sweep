using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemyScaner : MonoBehaviour
{
    [SerializeField] EnemyBaheviour _baheviour;

    void Start()
    {
        var sp = GetComponent<SphereCollider>();
        sp.isTrigger = true;
        sp.radius = _baheviour.Sets.SeeRange;
        
        //gameObject.AddComponent<Rigidbody>().isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_baheviour.Sets.Priority == EnemyBaheviour.TargetPriority.player) return;
        if (other.CompareTag("Player")) _baheviour.SetTarget(other.transform);
        Debug.Log(_baheviour.Body.name + "'s target is Player");
    }
    private void OnTriggerExit(Collider other)
    {
        if (_baheviour.Sets.Priority == EnemyBaheviour.TargetPriority.player) return;
        if (other.CompareTag("Player")) _baheviour.FindBuilding();
        Debug.Log(_baheviour.Body.name + "'s target is Building");
    }
}
