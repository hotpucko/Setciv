using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
	public float Speed;

	void Awake()
	{
		//transform.
	}


	void Update () {
		transform.position += new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis("Mouse ScrollWheel") * -10 * Speed, Input.GetAxis ("Vertical") * Speed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 100), Mathf.Clamp(transform.position.y, 5, 50), Mathf.Clamp(transform.position.z, -30, 70));
		/*if (Input.GetKeyDown (KeyCode.E)) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
			transform.rotatear
		}*/
	}
}
