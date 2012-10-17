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
	private Vector3 cursorOffset = new Vector3(5, 0, 0);
	
	public Camera cam;
	
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
		
		cam.transform.position = cursorPos + cursorOffset + new Vector3(0,5,0);
		cam.transform.LookAt(cursorPos, Vector3.up);
	}
	
	void doInput(){
		
		//TODO: @MJP make this easier to read!
		float rotDir = Input.GetAxis("HorizontalRight") * 2;
		float distDir = -Input.GetAxis("VerticalRight") * 0.2f;
		
		float cleanStickLeftX = Input.GetAxis("Horizontal") * 0.2f;
		float cleanStickLeftY = Input.GetAxis("Vertical") * 0.2f;
		
		float newCamLen = (cursorOffset.magnitude - distDir);
		if(newCamLen < 5 || newCamLen > 6)
			newCamLen = Mathf.Clamp(newCamLen, 5, 6);
		cursorOffset = cursorOffset.normalized * newCamLen;
		cursorOffset = Quaternion.AngleAxis(rotDir, Vector3.up) * cursorOffset;
		
		Vector3 xzForward = (-cursorOffset).normalized;
		//Debug.DrawRay(cursorPos, cursorOffset);
		//Debug.DrawRay(cursorPos, xzForward);
		
		Vector3 direction = (xzForward * cleanStickLeftY) + Vector3.Cross(Vector3.up, xzForward).normalized * cleanStickLeftX;
		
		//Debug.Log(direction.magnitude);
		
		cursorPos += direction;
		
		if(cursorPos.magnitude > 8)
			cursorPos = cursorPos.normalized * 8;
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
