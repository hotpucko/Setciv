using UnityEngine;
using System.Collections;

public class TankBullet : MonoBehaviour
{
	public float lifeTime;

	private float timer;

	void Start()
	{
		timer = lifeTime;
	}

	void Update () 
	{
		if(timer <= 0)
			Destroy(gameObject);

		timer -= Time.deltaTime;
	}

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag == "Tower" && !coll.collider.isTrigger)
		{
			Destroy(coll.gameObject);
			Destroy(gameObject);
		}
	}
}