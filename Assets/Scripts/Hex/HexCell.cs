using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexCell : MonoBehaviour {

    public HexCoordinates coordinates;

	public Color defaultColor { get; private set; }
	public Color highlightedColor { get; private set; }

	public HexMetrics.TileType tileType;

	bool settlemented = false;

	public GameObject settlementBuilding;
	private GameObject startingBuildingState;

    void Awake()
    {
		startingBuildingState = transform.GetChild (0).gameObject;

		switch (tileType) {
		case HexMetrics.TileType.Claypit:
			defaultColor = new Color32 (192, 192, 192, 255);
			break;
		case HexMetrics.TileType.Forest:
			defaultColor = new Color32 (0, 64, 0, 255);
			break;
		case HexMetrics.TileType.Mountain:
			defaultColor = new Color32 (128, 128, 128, 255);
			break;
		case HexMetrics.TileType.Settlement:
			defaultColor = new Color32(128, 64, 64, 255);//Brown-ish
			break;
		case HexMetrics.TileType.Water:
			defaultColor = Color.blue;
			highlightedColor = Color.cyan;
			break;
		case HexMetrics.TileType.Desert:
			defaultColor = Color.yellow;
			break;
		case HexMetrics.TileType.Pasture:
			defaultColor = new Color32 (0, 255, 0, 255);
			break;
		default:
			defaultColor = Color.white;
			break;
		}

		//highlightedColor = Color.yellow;

		 GetComponentInChildren<Renderer> ().material.color = defaultColor;
    }

	public void SettlementThis() {
		settlemented = true;
		(Instantiate (settlementBuilding, transform.position, transform.rotation) as GameObject).transform.parent = transform;
		Destroy (transform.GetChild (0).gameObject);
	}

	public void UnSettlementThis() {
		settlemented = false;
		(Instantiate (startingBuildingState, transform.position, transform.rotation) as GameObject).transform.parent = transform;
		Destroy (transform.GetChild (0).gameObject);
	}

	public string GetColorString() {
		return "R: " + defaultColor.r + ", G: " + defaultColor.g + ", B: " + defaultColor.b;
	}

	public void Hover() {
		GetComponentInChildren<Renderer> ().material.color = highlightedColor;
	}

	public void UnHover() {
		GetComponentInChildren<Renderer> ().material.color = defaultColor;
	}
}
