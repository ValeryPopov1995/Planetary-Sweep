using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Scriptable/Bullet config", order = 1)]
public class BulletConfig : ScriptableObject
{
    [Tooltip("if it for player bullets")]
    public PurchaseConfig PlayerBulletDamage;
    public bool EnemyBullet = true;
	public float Speed, Damage, TimerToDestroy, AccurecyAngle;
}