using UnityEngine;
using System.Collections;

public class Propel : MonoBehaviour {
	
	private float dieDistance = 10;
	
	public Vector3 velocity
	{
		set{ _velocity = value; }
	}
		
	private Vector3 _velocity = Vector3.forward;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += _velocity * Time.deltaTime;
		if(Vector3.Distance(transform.position, Vector3.zero) > dieDistance)
		{
			Destroy(this.gameObject);
		}
	}
	
	//Collision detection
	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag == "Enemy") {
			Debug.Log ("Projectile Destroyed");
			Destroy (this.gameObject);	
		}
	}
}
