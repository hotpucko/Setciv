using UnityEngine;
using System.Collections;

public class TankCamera : MonoBehaviour 
{
	public Transform Obj;
	public Transform Cam;
	public float speed = 10.0f;
	public int rotspeed = 1;


	void Start () 
	{
	
	}

	void Update () 
	{
		transform.position = Obj.position;

		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(new Vector3(0,40 * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(new Vector3(0,-40 * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(new Vector3(40 * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Rotate(new Vector3(-40 * Time.deltaTime,0,0));
		}

	}
	
}


