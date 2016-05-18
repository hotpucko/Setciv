using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	public Bullet BulletPrefab;
	public float reloadTime = 1f;
	public float rotationTime;
    public int damage;

	Transform Target;
	float nextFireTime;
	Bullet projectile;
    void Start ()
    {
        
    }

	void Update () 
	{
		if (Target) 
		{
			Quaternion _lookRotation = Quaternion.LookRotation ((transform.position - Target.transform.position).normalized);
			if (GetComponentInChildren<TurretTop> () != null)
				GetComponentInChildren<TurretTop> ().transform.rotation = Quaternion.Slerp (GetComponentInChildren<TurretTop> ().transform.rotation, _lookRotation, Time.deltaTime * rotationTime);
			else
				transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * rotationTime);

			if(Time.time >= nextFireTime)
			{
				FireBullet();
			}
		}
	}

    void OnTriggerExit(Collider other)
    {
		
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Monster")
		{
			Target = FindClosestEnemy().gameObject.transform;
		}
	}

	void FireBullet() {
		nextFireTime = Time.time + reloadTime;
		projectile = Instantiate (BulletPrefab, transform.position, Quaternion.identity) as Bullet;
        projectile.SetDamage(damage);
		projectile.GetComponent<Bullet>().target = Target;	
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


}
