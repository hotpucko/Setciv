using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
	public float Speed;

	void Awake()
	{
		//transform.
	}


	void Update () {
		transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")) * Speed;
		/*if (Input.GetKeyDown (KeyCode.E)) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
			transform.rotatear
		}*/
	}
}
