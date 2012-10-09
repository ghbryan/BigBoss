using UnityEngine;
using System.Collections;

public class BossManager : MonoBehaviour {
	
	public GameObject boss;
	public GameObject projectiles;
	public float shootPower = 1.0f;
	public float bulletLead = 0.25f;
	public float rotRadiansPerSecond = Mathf.PI / 2;
	
	public float coolDown = 0.1f;
	private float currCooldown = -1;
	
	private Vector3 currDirection = Vector3.forward;
	
	private Vector3 desiredDirection = Vector3.forward;
	
	// Use this for initialization
	void Start () {
		//Instantiate(boss, bossSpawnMarker.position, Quaternion.identity);
		boss.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
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
		currCooldown -= Time.deltaTime;
		
		if(Input.GetButton("Fire1") && currCooldown <= 0)
		{
			currCooldown = coolDown;
			GameObject newShot = (GameObject)(Instantiate (projectiles, boss.transform.position + (currDirection * bulletLead), boss.transform.rotation));
			newShot.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
			Propel propelScript = newShot.AddComponent<Propel>();
			propelScript.velocity = currDirection * shootPower;
		}
	}
}
