using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float maxHealth = 100.0f;
	public float currentHealth = 100.0f;
	public float moveSpeed = 0.5f;
	
	private GameObject boss;

	// Use this for initialization
	void Start () {
		boss = GameObject.FindGameObjectWithTag("Boss");
		transform.LookAt (boss.transform.position, Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {
		float destructDist = (boss.transform.localScale.x + transform.localScale.x) / 2;
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		
		if(Vector3.Distance(transform.position, boss.transform.position) <= destructDist) {
				Debug.Log ("Enemy Collided With Player");
				Destroy (this.gameObject);
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
		Debug.Log ("Enemy Hit For 25 HP");
		
		float percentRemaining = currentHealth / maxHealth;
		GetComponent<EntityUI>().lifePercent = percentRemaining;
		
		if(currentHealth <= 0) {
			Debug.Log ("Enemy Destroyed");
			Destroy (this.gameObject);	
		}
	}
}
