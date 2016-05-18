using UnityEngine;
using System.Collections;

public class MortarBullet : MonoBehaviour
{
    public float explosionRadius;
    public int damage;
	public float explosionTimer;

	private float timer;

	void Start()
	{
		timer = explosionTimer;
	}

	void Update()
	{
		timer -= Time.deltaTime;

		if(timer <= 0)
			Explode();
	}

    void OnCollisionEnter(Collision coll)
    {
		if(coll.gameObject.tag == "Floor" || coll.gameObject.tag == "Monster")
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider coll in colls)
        {
            GameObject go = coll.gameObject;
            if(go.tag == "Monster")
            {
                Health health = go.GetComponentInChildren<Health>();
                health.decrease(damage);
            }
        }
        Destroy(gameObject);
    }
}
