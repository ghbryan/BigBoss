using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public string[] enemyTypes;
	public GameObject[] enemyData;
	// Use this for initialization
	void Start () {
	
		enemyData = new GameObject[enemyTypes.Length];
		for(int i = 0; i < enemyData.Length; i++)
		{
			enemyData[i] = Resources.Load (enemyTypes[i]) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
