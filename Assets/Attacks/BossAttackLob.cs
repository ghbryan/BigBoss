using UnityEngine;
using System.Collections;

public class BossAttackLob: BossAttackBase{
	
	private const float shootCooldown = 0.9f;
	private const float buttetLead = 0.5f;
	private const float shotPower = 2.0f;
	private GameObject projectile;
	
	public void Start()
	{
		Init(shootCooldown, shootCooldown);
		projectile = Resources.Load("Bullet") as GameObject;
	}
	
	public override void Update()
	{
		base.Update();
	}

	protected override void Fire()
	{
		//newShot = (GameObject)(GameObject.Instantiate (projectile, Boss.transform.position + (Boss.CurrDirection * buttetLead), Boss.transform.rotation));
		//newShot.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		//propelScript = newShot.AddComponent<Propel>();
		//propelScript.velocity = Boss.CurrDirection * shotPower;
	}
}