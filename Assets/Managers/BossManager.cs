using UnityEngine;
using System.Collections;
using System;

public class BossManager : MonoBehaviour {
	
	public GameObject boss;
	public float rotRadiansPerSecond = Mathf.PI / 2;
	
	private Vector3 currDirection = Vector3.forward;
	public Vector3 CurrDirection
	{
		get { return currDirection; }
	}
	
	private Vector3 desiredDirection = Vector3.forward;
	
	public string [] attacksNames;
	private BossAttackBase [] attacks;
	
	// Use this for initialization
	void Start () {
		boss.transform.position = transform.position;
		attacks = new BossAttackBase[attacksNames.Length];
		for(int i = 0; i < attacks.Length; i++)
		{
			attacks[i] = gameObject.AddComponent(attacksNames[i]) as BossAttackBase;
			Debug.Log(attacks[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		for(int i = 0; i < attacks.Length; i++)
		{
			attacks[i].Update();
		}
		
		doInput();
	}
	
	void doInput(){
		Vector3 direction = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		if(direction.magnitude > 0.25) //Dead zone below 0.25
		{
			desiredDirection = direction.normalized;
		}
		currDirection = Vector3.RotateTowards(currDirection, desiredDirection, rotRadiansPerSecond * Time.deltaTime, 0);
		boss.transform.rotation = Quaternion.LookRotation(currDirection, Vector3.up);
		
		if(Input.GetButton("Fire1") && attacks.Length > 0)
		{
			attacks[0].AttemptFire();
		}
		if(Input.GetButton("Fire2") && attacks.Length > 1)
		{
			attacks[1].AttemptFire();
		}
		if(Input.GetButton("Fire3") && attacks.Length > 2)
		{
			attacks[2].AttemptFire();
		}
	}
}
