using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexCell : MonoBehaviour {

    public HexCoordinates coordinates;

	public Color defaultColor { get; private set; }// = Color.white;
	public Color highlightedColor { get; private set; }// = Color.magenta;

	public HexMetrics.TileType tileType;

    void Awake()
    {
		switch (tileType) {
		case HexMetrics.TileType.Claypit:
			defaultColor = Color.grey;
			break;
		case HexMetrics.TileType.Forest:
			defaultColor = Color.green;
			break;
		case HexMetrics.TileType.Mountain:
			defaultColor = Color.grey;
			break;
		case HexMetrics.TileType.Settlement:
			defaultColor = Color.cyan;
			break;
		default:
			defaultColor = Color.white;
			break;
		}

		GetComponent<Renderer> ().material.color = defaultColor;
    }
}
