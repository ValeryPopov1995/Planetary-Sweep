using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// поворачивается в сторону игрока, учитывая ось по направлению к планете (стоит вертикально к планете)
/// стреляет пуялми из бассейна
public class EnemyMarine : EnemyTrooper
{
    [SerializeField] GameObject Parashute;
    public float ParashuteVelocity, ParashuteTimer = 3;

    new void Start()
    {
        base.Start();
        StartCoroutine(closeParashute());
    }

    // TODO parashute baheviour
    IEnumerator closeParashute()
    {
        yield return new WaitForSeconds(ParashuteTimer);
        ParashuteVelocity = 0;
    }
}
