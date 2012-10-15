using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public GameObject[] enemyTypes;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public GameObject[] GetEnemies() {
		return enemyTypes;
	}
}
