using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HUDscript : MonoBehaviour {

	public enum Towers {Tower1, Tower2, none}
	public Towers selectedTower;
    public static int cash = 45;
    public List<Tower> TowerPrefabList = new List<Tower>();

    

    Tower tower;
    
	void OnGUI()
	{
		if (GUI.Button (new Rect (50, 50, 100, 50), "Tower1 " + TowerPrefabList[0].cost + "g")) {

			if(selectedTower == Towers.Tower1)
				selectedTower = Towers.none;
			else
				selectedTower = Towers.Tower1;
		}
		if (GUI.Button (new Rect (50, 100, 100, 50), "Tower2 " + TowerPrefabList[1].cost + "g")) {
			if(selectedTower == Towers.Tower2)
				selectedTower = Towers.none;
			else
				selectedTower = Towers.Tower2;
		}

		GUI.Label (new Rect (0, 0, 100, 70), selectedTower.ToString());
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 70), cash.ToString() + "g");
	}

	// Use this for initialization
	void Start () {
	
		selectedTower = Towers.none;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
