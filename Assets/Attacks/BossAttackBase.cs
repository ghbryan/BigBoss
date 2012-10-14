using UnityEngine;
using System.Collections;

public class BossAttackBase : MonoBehaviour{
	
	private float minCooldown, maxCooldown;
	
	private float cooldown = 0;
	public float Cooldown
	{
		get { return cooldown; }
	}
	
	private BossManager bossRef;
	protected BossManager Boss
	{
		get { return bossRef; }
	}
	
	protected void Init(float _cooldownMin, float _cooldownMax)
	{
		minCooldown = _cooldownMin;
		maxCooldown = _cooldownMax;
		
		bossRef = GameObject.Find("BossManager").GetComponent<BossManager>();
		if(bossRef == null)
			Debug.LogError("BossAttackBase():Init: Didn't get the BossManager component correctly");
	}
	
	public virtual void Update()
	{
		cooldown -= Time.deltaTime;
	}
	
	public void AttemptFire()
	{
		if(cooldown < 0)
		{
			Fire();
			cooldown = Random.Range(minCooldown, maxCooldown);
		}
	}
	
	protected virtual void Fire()
	{
		//Children classes will define this
	}
	
}
