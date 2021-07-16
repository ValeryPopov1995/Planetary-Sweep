using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public void RotateToPlanet()
    {
        Vector3 targetDir = (transform.position - Vector3.zero).normalized;
        transform.rotation = Quaternion.FromToRotation(transform.up, targetDir) * transform.rotation;
    }
}
