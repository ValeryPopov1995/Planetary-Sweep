using UnityEngine;

public class DeploymentShip : MonoBehaviour
{
    public float TimeToDeploy, DestroyTimer = 15;
    public GameObject[] SpownEnemies;

    void Start()
    {
        foreach(var e in SpownEnemies) e.SetActive(false);
        Invoke("deploy", TimeToDeploy);
        Destroy(gameObject, DestroyTimer);
    }

    void deploy()
    {
        foreach(var e in SpownEnemies)
        {
            e.SetActive(true);
            e.transform.SetParent(null);
        }
    }
}
