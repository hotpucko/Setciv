using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour 
{
	public float speed;

	public float speedIncrease;
	public float maxSpeed;
	public float turnSpeed;

	private Rigidbody body;


	void Start () 
	{
		body = GetComponent<Rigidbody>();
	}

	void Update () 
	{
		if(Input.GetKey(KeyCode.W))
		{
			speed = Mathf.Clamp(speed + speedIncrease, 0, maxSpeed);
		}
		else if(Input.GetKey(KeyCode.S) && speed <= 0.1f)
		{
			speed = Mathf.Clamp(speed + speedIncrease, -maxSpeed, 0);
		}
		else
		{
			speed = Mathf.Lerp(speed, 0, Time.deltaTime * 100);
		}
    }

	private void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			transform.Rotate((Vector3.down * turnSpeed));
		}

		if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
		{
			transform.Rotate((Vector3.up * turnSpeed));
		}
		body.MovePosition(transform.position + (transform.forward * speed));
	}
}
