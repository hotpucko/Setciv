using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MortarScript : MonoBehaviour
{
    public float FireRate = 5;
    public GameObject BulletPrefab;
    public float firePower;

	private GameObject target;
    private float timer;
    
	void Update ()
    {
        timer -= Time.deltaTime;

		if(target != null)
        {

			Quaternion lookRotation = Quaternion.LookRotation((target.transform.position - transform.position).normalized);
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 4);

			if (timer <= 0) 
			{
				Fire (new Vector3(target.transform.position.x, target.transform.position.y - 1, target.transform.position.z));
				timer = FireRate;
			}
        }
	}

    void OnTriggerEnter(Collider coll)
    {
		if (coll.tag == "Monster")
			target = FindClosestEnemy ();

    }

	GameObject FindClosestEnemy()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Monster");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
    
    void Fire(Vector3 targetPosition)
    {
		Transform go = gameObject.transform;
        go.LookAt(targetPosition);

		GameObject go2 = Instantiate(BulletPrefab, transform.position, go.rotation) as GameObject;
		go2.transform.position = new Vector3(go2.transform.position.x, go2.transform.position.y + 1, go2.transform.position.z);
		go2.GetComponent<Rigidbody>().velocity = transform.forward * firePower;
    }
}
