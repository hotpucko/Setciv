using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	public Bullet BulletPrefab;
	public float reloadTime = 1f;
	public float rotationTime;
    public int damage;
    public int cost;

	Transform Target;
	float nextFireTime;
	Bullet projectile;

	//List<Transform> targets = new List<Transform>();

    void Start ()
    {
        
    }

	// Update is called once per frame
	void Update () {

        //if (targets.Count > 0)
        //{
        //    for (int i = 0; i < targets.Count; i++)
        //    {
        //        if (targets[i] == null)
        //        {
        //            targets.RemoveAt(i);
        //        }
        //    }

        //    Target = targets[0];
        //}
        //else
        //    Target = null; 


		if (Target) {
			Quaternion _lookRotation = Quaternion.LookRotation ((transform.position - Target.transform.position).normalized);
			GetComponentInChildren<TurretTop>().transform.rotation = Quaternion.Slerp(GetComponentInChildren<TurretTop>().transform.rotation, _lookRotation, Time.deltaTime * rotationTime);


			//Debug.Log("Target!");

			if(Time.time >= nextFireTime){
				FireBullet();

			}


		}


	}

    void OnTriggerExit(Collider other)
    {
        //for (int i = 0; i < targets.Count; i++)
        //{
        //    if(other.transform == targets[i])
        //    {
        //        targets.RemoveAt(i);
        //    }
        //}
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Monster"){

			//Debug.Log("Monster tag detected");

			//nextFireTime = (float)(Time.time+(reloadTime*0.5));
            //targets.Add(other.transform);
			Target = FindClosestEnemy().gameObject.transform;

		}
	}

	void FireBullet() {

		//Debug.Log ("Pew");

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
