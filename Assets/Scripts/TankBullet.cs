using UnityEngine;
using System.Collections;

public class TankBullet : MonoBehaviour
{
	public GameObject Bullet;
	public int ShootDelay;
	public int power = 100;
	void Start () 
	{
	
	}

	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.K)) 
		{
			Shoot();
		}


	
	}


	void Shoot()
	{
		GameObject b = Instantiate (Bullet, transform.position, transform.rotation) as GameObject;
		b.GetComponent<Rigidbody> ().AddForce (b.transform.forward * power);
	}
}