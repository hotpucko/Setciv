using UnityEngine;
using System.Collections;

public class playerGold : MonoBehaviour {


	public	int TurretPlayer;
	public	int TankPlayer = 100;
	public float tankIncome = 0;
	public int CurrentIncome = 10;
	GameObject spawnsystem;
	// Use this for initialization
	void Start () {
		//get the spawnsystem gameobject
		spawnsystem = GameObject.Find ("Spawn");
	}
	
	void Update () {
		tankIncome += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.F1) && TankPlayer >= 20) 
		{
			spawnsystem.GetComponent<Spawn>().SpawnNext(0);
			TankPlayer -= 20;
			CurrentIncome += 1;
		}
		if (Input.GetKeyDown (KeyCode.F2) && TankPlayer >= 40) 
		{
			spawnsystem.GetComponent<Spawn>().SpawnNext(1);
			TankPlayer -= 40;
			CurrentIncome += 2;
		}
		if (Input.GetKeyDown (KeyCode.F3) && TankPlayer >= 60) 
		{
			spawnsystem.GetComponent<Spawn>().SpawnNext(2);
			TankPlayer -= 60;
			CurrentIncome += 3;
		}

		if (tankIncome >= 2) {
			TankPlayer += CurrentIncome;
			tankIncome = 0;
		}
	}

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 70), "Tank gold: " + TankPlayer.ToString());

        if (GUI.Button(new Rect(0, 50, 200, 50), "F1, cost: 20g, income: 1g") && TankPlayer >= 10)
        {
        }
        if (GUI.Button(new Rect(0, 100, 200, 50), "F2, cost: 40g, income: 2g") && TankPlayer >= 20)
        {
        }
        if (GUI.Button(new Rect(0, 150, 200, 50), "F3, cost: 60g, income: 3g") && TankPlayer >= 30)
        {
        }
    }
}
