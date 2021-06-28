using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemyScaner : MonoBehaviour
{
    public EnemyBaheviour Baheviour;

    void Start()
    {
        var sp = GetComponent<SphereCollider>();
        sp.isTrigger = true;
        sp.radius = Baheviour.Sets.SeeRange;
        
        //gameObject.AddComponent<Rigidbody>().isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Baheviour.Sets.Priority == EnemyBaheviour.TargetPriority.player) return;
        if (other.CompareTag("Player")) Baheviour.SetTarget(other.transform);
        Debug.Log(Baheviour.Body.name + "'s target is Player");
    }
    private void OnTriggerExit(Collider other)
    {
        if (Baheviour.Sets.Priority == EnemyBaheviour.TargetPriority.player) return;
        if (other.CompareTag("Player")) Baheviour.FindBuilding();
        Debug.Log(Baheviour.Body.name + "'s target is Building");
    }
}
