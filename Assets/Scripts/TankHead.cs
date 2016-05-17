using UnityEngine;
using System.Collections;

public class TankHead : MonoBehaviour 
{

	public float cameraRotationSpeed;

	public bool Horizontal;

	public GameObject bulletPrefab;
	public float fireRate;
	public float firePower = 100;

	private float timer;

	void Start () 
	{
	}

	void Update () 
	{
		if(Horizontal)
		{
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.Rotate(new Vector3(0, 1, 0) * cameraRotationSpeed, Space.Self);
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Rotate(-new Vector3(0, 1, 0) * cameraRotationSpeed, Space.Self);
			}
		}
		else
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				transform.Rotate(-new Vector3(1, 0, 0) * cameraRotationSpeed, Space.Self);
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.Rotate(new Vector3(1, 0, 0) * cameraRotationSpeed, Space.Self);
			}



			timer -= Time.deltaTime;

			if(Input.GetKey(KeyCode.K) && timer <= 0)
			{
				Shoot();
				timer = fireRate;
			}

		}

		Vector3 newRot = transform.localRotation.eulerAngles;

		//newRot.x = Mathf.Clamp(newRot.x, -45, 45);
		//newRot.y = Mathf.Clamp(newRot.y, -45, 45);

		transform.localRotation = Quaternion.Euler(newRot);

	}

	void Shoot()
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * firePower);
		bullet.GetComponent<Rigidbody>().velocity = transform.forward * firePower;
	}
}
