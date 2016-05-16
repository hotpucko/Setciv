using UnityEngine;
using System.Collections;

public class playerGold : MonoBehaviour {


	public	int TurretPlayer;
	public	int TankPlayer = 100;
	public int tankIncome = 0;
	public int CurrentIncome = 10;
	GameObject spawnsystem;
	// Use this for initialization
	void Start () {
		//get the spawnsystem gameobject
		spawnsystem = GameObject.Find ("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
	//	if (!Monster && !Monster.isDestroyed)
		//	Monster.
	

		if (Input.GetKeyDown (KeyCode.F1) && TankPlayer >= 10) 
		{
		
			//spawnsystem.GetComponent<Spawn>().SpawnNext(0);
			TankPlayer -= 10;
			CurrentIncome += 1;
		}
		if (Input.GetKeyDown (KeyCode.F2) && TankPlayer >= 20) 
		{
			
			//spawnsystem.GetComponent<Spawn>().SpawnNext(1);
			TankPlayer -= 20;
			CurrentIncome += 2;
		}
		if (Input.GetKeyDown (KeyCode.F3) && TankPlayer >= 30) 
		{
			
			//spawnsystem.GetComponent<Spawn>().SpawnNext(2);
			TankPlayer -= 30;
			CurrentIncome += 3;
		}

		if (tankIncome >= 300) {
			TankPlayer += CurrentIncome;
			tankIncome = 0;
		}
		tankIncome ++;
	}
}
