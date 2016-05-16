using UnityEngine;
using System.Collections;

public class pCube1 : MonoBehaviour {

	public GameObject player;
	Vector3 offset;

	void Start () 
	{

		offset = transform.position - player.transform.position;

	}

	void Update () 
	{
		transform.position = new Vector3 (player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
	}
}
