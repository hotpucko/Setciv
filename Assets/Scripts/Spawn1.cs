using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Spawn1 : MonoBehaviour {
	// The Monster that should be spawned
	public List<GameObject> monsterPrefab = new List<GameObject> ();
	
	// Spawn Delay in seconds
	public float interval = 10;
	
	// Use this for initialization
	void Start() 
	{
		//InvokeRepeating("SpawnNext", interval, interval);
	}
	
	public void SpawnNext(int monstertype = 1) 
	{
		Instantiate(monsterPrefab[monstertype], transform.position, Quaternion.identity);
	}

	void Uppdate() 
	{
	
	}
}