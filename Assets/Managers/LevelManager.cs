using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public GameObject[] enemyTypes;
	public float maxThreat;
	
	private float curThreat;
	
	// Use this for initialization
	void Start () {
		curThreat = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public GameObject[] GetEnemies() {
		return enemyTypes;
	}
	
	public void UpdateThreat (float threatLevel) {
		curThreat += threatLevel;
	}
	public float CurrentThreat() {
		return curThreat;	
	}
	
	public bool ThreatLimitReached() {
		if (maxThreat - curThreat > 0) {
			return false;
		}
		else {
			return true;	
		}
	}
}
