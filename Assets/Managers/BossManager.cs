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
	
	private Vector3 cursorPos = Vector3.zero;
	private GameObject cursorObj;
	
	private Vector3 cursorCurrPos = Vector3.zero;
	private GameObject cursorCurrObj;
	
	private Vector3 desiredDirection = Vector3.forward;
	
	public string [] attacksNames;
	private BossAttackBase [] attacks;
	
	public float cursorSensitivity = 0.25f;
	
	// Use this for initialization
	void Start () {
		boss.transform.position = transform.position;
		attacks = new BossAttackBase[attacksNames.Length];
		for(int i = 0; i < attacks.Length; i++)
		{
			attacks[i] = gameObject.AddComponent(attacksNames[i]) as BossAttackBase;
			Debug.Log(attacks[i]);
		}
		cursorObj = GameObject.Find("Cross");
		cursorCurrObj = Instantiate(cursorObj) as GameObject;
		cursorCurrObj.GetComponent<Light>().color = Color.red;
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
		Vector3 direction = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * cursorSensitivity;
		cursorPos += direction;
		
		cursorPos.x = Mathf.Clamp(cursorPos.x, -10, 10);
		cursorPos.z = Mathf.Clamp(cursorPos.z, -10, 10);
		
		cursorCurrPos = boss.transform.position + (currDirection * Vector3.Distance(cursorPos, boss.transform.position));

		cursorObj.transform.position = cursorPos + new Vector3(0,5,0);
		cursorCurrObj.transform.position = cursorCurrPos + new Vector3(0,5,0);
		
		desiredDirection = cursorPos.normalized;
		
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
