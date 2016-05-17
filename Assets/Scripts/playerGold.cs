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
	
	void Update () {
	

		if (Input.GetKeyDown (KeyCode.F1) && TankPlayer >= 10) 
		{
		
			
		}
		if (Input.GetKeyDown (KeyCode.F2) && TankPlayer >= 20) 
		{
			spawnsystem.GetComponent<Spawn>().SpawnNext(1);
			TankPlayer -= 20;
			CurrentIncome += 2;
		}
		if (Input.GetKeyDown (KeyCode.F3) && TankPlayer >= 30) 
		{
			spawnsystem.GetComponent<Spawn>().SpawnNext(2);
			TankPlayer -= 30;
			CurrentIncome += 3;
		}

		if (tankIncome >= 300) {
			TankPlayer += CurrentIncome;
			tankIncome = 0;
		}
		tankIncome ++;
	}

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 70), "Tank gold: " + TankPlayer.ToString());

        if (GUI.Button(new Rect(0, 50, 200, 50), "monster1, cost: 10g, income: 1g") && TankPlayer >= 10)
        {
            spawnsystem.GetComponent<Spawn>().SpawnNext(0);
            TankPlayer -= 10;
            CurrentIncome += 1;
        }
        if (GUI.Button(new Rect(0, 100, 200, 50), "monster1, cost: 20g, income: 2g") && TankPlayer >= 20)
        {
            spawnsystem.GetComponent<Spawn>().SpawnNext(1);
            TankPlayer -= 20;
            CurrentIncome += 2;
        }
        if (GUI.Button(new Rect(0, 150, 200, 50), "monster1, cost: 30g, income: 3g") && TankPlayer >= 30)
        {
            spawnsystem.GetComponent<Spawn>().SpawnNext(2);
            TankPlayer -= 30;
            CurrentIncome += 3;
        }
    }
}
