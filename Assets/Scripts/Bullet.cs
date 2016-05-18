using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 10;
	public Transform target;
    int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

	void FixedUpdate() {    
		// Still has a Target?
		if (target) {
			// Fly towards the target        
			Vector3 dir = target.position - transform.position;
			GetComponent<Rigidbody>().velocity = dir.normalized * speed;
		} else {
			// Otherwise destroy self
			Destroy(gameObject);
		}
	}

    

	void OnCollisionEnter(Collider other) {
		Health health = other.GetComponentInChildren<Health>();
		if (health) {
			health.decrease(damage);
			Destroy(gameObject);
		}
	}
}
