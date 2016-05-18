using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Spawn : MonoBehaviour {
	// The Monster that should be spawned
	public List<GameObject> monsterPrefab = new List<GameObject> ();

    // Spawn Delay in seconds
    public float interval = 2;
	
	void Awake() 
	{
        StartCoroutine(Timer());
	}
	
	public void SpawnNext(int monstertype = 0)
	{
		Instantiate(monsterPrefab[monstertype], transform.position, Quaternion.identity);
	}

    private IEnumerator Timer()
    {
        while(true)
        {
            SpawnNext();
            yield return new WaitForSeconds(interval);
        }
    }
}