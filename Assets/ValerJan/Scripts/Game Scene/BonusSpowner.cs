using System.Collections;
using UnityEngine;

public class BonusSpowner : MonoBehaviour
{
    GameBalanceConfig _balance;
    GameObject[] _bonuses;
    [SerializeField] int _altitude = 100;

    void Start()
    {
        _balance = Settings.Singleton.GameBalance;
        _bonuses = Settings.Singleton.Prefabs.Bonuses;
        StartCoroutine(startSpown());
    }

    IEnumerator startSpown()
    {
        int limit = 100; // подарочки не отдарочки
        while(limit > 0)
        {
            limit--;

            Vector3 dropPos = Random.insideUnitSphere * _altitude;
            Instantiate(
                _bonuses[Random.Range(0, _bonuses.Length-1)],
                dropPos, Quaternion.identity);
            Debug.Log("bonus spowned");
            
            yield return new WaitForSeconds(
                _balance.BonuseSecondRate +
                Random.Range(0, _balance.BonusRandomAdditive));
        }
    }
}
