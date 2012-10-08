using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
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
				Destroy (this.gameObject);
		}
	}
}
