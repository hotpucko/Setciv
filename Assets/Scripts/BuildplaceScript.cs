using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildplaceScript : MonoBehaviour {
		
	public GameObject cam;
	public List<GameObject> towerPrefabList = new List<GameObject>();

	HUDscript.Towers selectedTower; 
	GameObject towerPrefab;
	HUDscript hudscript;
    bool occupied;

	void Start()
	{
	
		hudscript = cam.GetComponent<HUDscript>();
        occupied = false;

	}



	void OnMouseUpAsButton() 
	{
		selectedTower = hudscript.selectedTower;

		//Debug.Log ("selectedTower = " + selectedTower.ToString());

		switch (selectedTower) {
		
		case HUDscript.Towers.Tower1:
			//set towerprefab to Tower1
			towerPrefab = towerPrefabList[0];
			break;

		case HUDscript.Towers.Tower2:
			//set towerprefab to tower2
			towerPrefab = towerPrefabList[1];
			break;
        case HUDscript.Towers.Tower3:
                towerPrefab = towerPrefabList[2];
            break;
		default:
			break;
		}

        if (selectedTower != HUDscript.Towers.none)
        {
            GameObject tow = towerPrefab;
            if (HUDscript.cash >= tow.GetComponent<GoldCost>().Cost && !occupied)
            {
                GameObject go = Instantiate(towerPrefab);
                go.transform.position = transform.position + Vector3.up - new Vector3(0, 0.5f, 0);
                HUDscript.cash -= tow.GetComponent<GoldCost>().Cost;
                occupied = true;
            }
        }
	}


	
}
