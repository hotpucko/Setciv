using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour 
{
	public GameObject bulletPrefab;
	public float rotationSpeed;
	public float fireRate;
    public float firePower = 100;
	public float speed;
    public Camera cam;

    private float timer;

	void Start () 
	{
        timer = fireRate;
	}

	void Update () 
	{
        #region Movement
        
        transform.Translate(transform.forward * Input.GetAxis("Vertical") * speed);
        transform.Rotate(transform.up * Input.GetAxis("Horizontal") * rotationSpeed);
        //transform.Translate(transform.right * Input.GetAxis("Horizontal") * speed);
        #endregion

        #region CameraMovement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(transform.right * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-transform.right * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(-transform.up * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(transform.up * rotationSpeed);
        }
        #endregion

        #region Shooting
        timer -= Time.deltaTime;

        if(Input.GetKey(KeyCode.K) && timer <= 0)
        {
            Shoot();
            timer = fireRate;
        }
        #endregion
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bulletPrefab.GetComponent<Rigidbody>().AddForce(bulletPrefab.transform.forward * firePower);
    }
}
