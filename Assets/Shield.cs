using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameObject.GetComponent<Enemy>().IsMoving())
		{
			Deploy();
		}
	}
	
	void Deploy () {
		//Code for deploying shield	
	}
}
