using UnityEngine;
using System.Collections;

public class TankHead : MonoBehaviour 
{
	Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update () 
	{
        Quaternion newRotation = transform.rotation;

		newRotation.x += Input.GetAxis ("Mouse X") * 100 * Time.deltaTime;
	    newRotation.y += Input.GetAxis ("Mouse Y") * 100 * Time.deltaTime;
		newRotation.y = Mathf.Clamp (newRotation.y, -45, 45);
        transform.rotation = newRotation;
	}
}
