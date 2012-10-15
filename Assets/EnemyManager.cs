using UnityEngine;
using System.Collections;
using System.Linq;

public class EnemyManager : MonoBehaviour {
	
	private GameObject[] spawners;
	private GameObject[] enemyTypes;
	
	public float minTimer = 2.0f;
	public float maxTimer = 4.0f;
	
	private float spawnDelay;
	
	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
		enemyTypes = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag=="Enemy").ToArray();
		spawnDelay = minTimer;
	}
	
	// Update is called once per frame
	void Update () {
		spawnDelay -= Time.deltaTime;
		
		if(spawnDelay <= 0) {
			Vector3 spawnPos = spawners[Random.Range (0, spawners.Length)].transform.position;
			
			if(enemyTypes.Length > 0)
			{
				GameObject nextEnemyType = enemyTypes[Random.Range (0, enemyTypes.Length)];
				GameObject newEnemy = (GameObject)Instantiate (nextEnemyType, spawnPos, Quaternion.identity);
				//newEnemy.AddComponent<Enemy>();
			}
			else
			{
				Debug.Log("EnemyManager:Update(): No enemyTypes found!");	
			}
			
			spawnDelay = Random.Range (minTimer, maxTimer);
		}
	}
}
