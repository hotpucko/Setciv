using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public Text tileInfo;

	HexCell lastTouchedCell = null;
    
	HexCell selectedCell;

	void Update(){
		HandleInput();
	}

    public void WriteTileInfo(string info) {
        tileInfo.text = info;
    }

	void HandleInput() {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)){
			HexCell touchedCell = hit.collider.gameObject.transform.parent.gameObject.GetComponent<HexCell>();

			if (touchedCell != lastTouchedCell) {
				if (lastTouchedCell != null) {
					lastTouchedCell.UnHover ();
				}
			}
			touchedCell.Hover();

			if(Input.GetMouseButtonDown(0))
				TouchCell(touchedCell);

			if (Input.GetKeyDown (KeyCode.Y))
				SettlementCell (selectedCell);
			if (Input.GetKeyDown (KeyCode.U))
				UnSettlementCell (selectedCell);
			
			lastTouchedCell = touchedCell;
		}
	}

	void TouchCell(HexCell touchedCell) {
		selectedCell = touchedCell;
		WriteTileInfo ("Selected Tile: " + touchedCell.tileType.ToString () + "\n" + touchedCell.GetColorString());
	}

	void SettlementCell(HexCell selectedCell) {
		if(selectedCell != null)
			selectedCell.SettlementThis ();
	}

	void UnSettlementCell(HexCell selectedCell) {
		if(selectedCell != null)
			selectedCell.UnSettlementThis ();
	}
}
