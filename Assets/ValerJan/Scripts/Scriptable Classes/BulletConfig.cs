using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Scriptable/Bullet config", order = 1)]
public class BulletConfig : ScriptableObject
{
    public bool EnemyBullet = true;
	public float Speed, Damage, TimerToDestroy;
}