using UnityEngine;
using System.Collections;
using System.Linq;

public class EnemyManager : MonoBehaviour {
	
	private GameObject[] spawners;
	private GameObject[] enemyTypes;
	
	private GameObject levelManager;
	
	public float minTimer = 2.0f;
	public float maxTimer = 4.0f;
	
	private float spawnDelay;
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find ("LevelManager");
		spawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
		enemyTypes = levelManager.GetComponent<LevelManager>().GetEnemies();
		spawnDelay = minTimer;
	}
	
	// Update is called once per frame
	void Update () {
		spawnDelay -= Time.deltaTime;
		
		if(spawnDelay <= 0) {
			Vector3 spawnPos = spawners[Random.Range (0, spawners.Length)].transform.position;
			
			if(enemyTypes.Length > 0 && !levelManager.GetComponent<LevelManager>().ThreatLimitReached())
			{
				GameObject nextEnemyType = enemyTypes[Random.Range (0, enemyTypes.Length)];
				
				if((nextEnemyType.GetComponent<Enemy>().threatLevel + levelManager.GetComponent<LevelManager>().CurrentThreat()) <= levelManager.GetComponent<LevelManager>().maxThreat) {
					GameObject newEnemy = (GameObject)Instantiate (nextEnemyType, spawnPos, Quaternion.identity);
					levelManager.GetComponent<LevelManager>().UpdateThreat(newEnemy.GetComponent<Enemy>().threatLevel);
				}
			}
			else
			{
				Debug.Log("EnemyManager:Update(): No enemyTypes found!");;
			}
			
			spawnDelay = Random.Range (minTimer, maxTimer);
		}
	}
}
