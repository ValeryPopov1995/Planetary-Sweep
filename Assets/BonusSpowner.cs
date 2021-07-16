using System.Collections;
using UnityEngine;

public class BonusSpowner : MonoBehaviour
{
    GameBalanceConfig _balance;
    GameObject[] _bonuses;
    int _altitude = 100;

    void Start()
    {
        _balance = Settings.Singleton.GameBalance;
        _bonuses = Settings.Singleton.Prefabs.Bonuses;
    }

    IEnumerator startSpown()
    {
        int limit = 100; // подарочки не отдарочки
        while(limit > 0)
        {
            limit--;

            Vector3 dropPos = Random.insideUnitSphere * _altitude;
            Instantiate(
                _bonuses[Random.Range(0, _bonuses.Length)],
                dropPos, Quaternion.identity);
            
            yield return new WaitForSeconds(
                _balance.BonuseSecondRate +
                Random.Range(0, _balance.BonusRandomAdditive));
        }
    }
}
