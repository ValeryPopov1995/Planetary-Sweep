using UnityEngine;

public class Planet : MonoBehaviour
{
    [HideInInspector] public float PlanetaryHealth { get; private set; }

    public int SecondsAward;
    public PlanetaryWavesConfig PlanetaryWaves;
    public Transform StartPlayerPosition;
    public Transform[] DeployPoints;

    void Start()
    {
        EventHolder.Singleton.PlanetChangeHealth += changeHealth;

        if (DeployPoints.Length == 0) Debug.LogError("нет точек десантирования");
        foreach(var e in DeployPoints)
        {
            Vector3 targetDir = (e.position - transform.position).normalized;
            e.rotation = Quaternion.FromToRotation(e.up, targetDir);
        }

        EventHolder.Singleton.PlanetLoaded(this);
    }

    void changeHealth(float value)
    {
        PlanetaryHealth += value;
        if (PlanetaryHealth < 0)
        {
            Debug.Log("Defeat : planet damaged");
            EventHolder.Singleton.EndGame?.Invoke(false);
        }
    }
}
