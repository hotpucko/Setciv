using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public int loot;

	// Use this for initialization
	void Start () {
	
		GameObject mewtwo = GameObject.Find ("Mewtwo");

		if (mewtwo)
			GetComponent<NavMeshAgent> ().destination = mewtwo.transform.position;

	}

    void OnDestroy()
    {
        HUDscript.cash += loot;
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Castle") {
			other.GetComponentInChildren<Health>().decrease(1);
			Destroy(gameObject);
		}
	}

}
