using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	Rigidbody rb;

	public float speed;	
	public Rigidbody Bullet;
	float x;
	float y;
	public Rigidbody projectile;
	Vector2 yAccelereation;
	public float rotation;
	public float rotatoinspeed;


	public float gravity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	
	// Update is called once per frame
	void Update () 
	{

	}
		
                                  
	
	void FixedUpdate()
	{   
		if (Input.GetKey(KeyCode.W)) 
		{
			rb.AddRelativeForce (Vector3.forward * speed);
		}
		if (Input.GetKey(KeyCode.S)) 
		{
			rb.AddRelativeForce (Vector3.back * speed);
		}
		if (Input.GetKey(KeyCode.A)) 
		{
			transform.Rotate (new Vector3(0,-10 * Time.deltaTime,0));
		}
		if (Input.GetKey(KeyCode.D)) 
		{
			transform.Rotate (new Vector3(0,10 * Time.deltaTime,0));
		}


	}
}

