using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MortarScript : MonoBehaviour
{
    public float FireRate = 5;
    public GameObject BulletPrefab;
    public float firePower;

    private List<GameObject> targets = new List<GameObject>();

    private float timer;
    
	void Update ()
    {
        timer -= Time.deltaTime;

	    if(targets.Count > 0 && timer <= 0)
        {
            if (targets[0] == null)
            {
                targets.RemoveAt(0);
                return;
            }
            Fire(targets[0].transform.position);
            timer = FireRate;
        }
        
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Monster")
            targets.Add(coll.gameObject);

    }
    
    void Fire(Vector3 targetPosition)
    {
        GameObject go = gameObject;
        go.transform.LookAt(targetPosition);
        
        GameObject go2 = Instantiate(BulletPrefab, transform.position, go.transform.rotation) as GameObject;

        go2.GetComponent<Rigidbody>().velocity = transform.forward * firePower;
    }
}
