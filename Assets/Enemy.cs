using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float maxHealth = 100.0f;
	private float currentHealth = 100.0f;
	
	public float moveSpeed = 0.5f;
	public float attackDistance = 1.0f;
	public float threatLevel = 1.0f;
	
	private bool moving = true;
	
	private GameObject boss;
	private float destructDist;


	// Use this for initialization
	void Start () {
		boss = GameObject.FindGameObjectWithTag("Boss");
		transform.LookAt (boss.transform.position, Vector3.up);
		
		destructDist = (boss.transform.localScale.x + transform.localScale.x) / 2;
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {		
		if(Vector3.Distance(transform.position, boss.transform.position) <= destructDist) {
				Debug.Log ("Enemy Collided With Player");
				Destroy (this.gameObject);
		}
				
		if (moving && (Vector3.Distance (transform.position, boss.transform.position) >= attackDistance)) {
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
		else {
			moving = false;	
		}
	}
	
	//Collision detection
	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag == "boss_projectile") {
			TakeDamage (25.0f);
		}
	}
	
	void TakeDamage(float damage) {
		currentHealth -= damage;
		Debug.Log ("Enemy Hit For " + damage + " HP");
		
		float percentRemaining = currentHealth / maxHealth;
		GetComponent<EntityUI>().lifePercent = percentRemaining;
		
		if(currentHealth <= 0) {
			Debug.Log ("Enemy Destroyed");
			Destroy (this.gameObject);	
			GameObject.Find ("LevelManager").GetComponent<LevelManager>().UpdateThreat(-threatLevel);
		}
	}
}
