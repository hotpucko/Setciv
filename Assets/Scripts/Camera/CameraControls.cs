using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
	public float Speed;
    public Transform cam;

	void Awake()
	{
		//transform.
	}


	void Update () {
		transform.Translate( new Vector3 (Input.GetAxis ("Horizontal") * Speed, 0, Input.GetAxis ("Vertical") * Speed));
        transform.Rotate(new Vector3(0, Input.GetAxis("Rotate") * 3f, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -20, 120), Mathf.Clamp(transform.position.y, 1, 2), Mathf.Clamp(transform.position.z, -20, 120));
        if (cam.position.y <= 50 && cam.position.y >= 20)
        {
            cam.Translate(new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * 25f, 0), Space.World);
        }
        cam.position = new Vector3(cam.position.x, Mathf.Clamp(cam.position.y, 20, 50),cam.position.z);
        /*if (Input.GetKeyDown (KeyCode.E)) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
			transform.rotatear
		}*/
    }
}
