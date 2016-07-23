using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexCell : MonoBehaviour {

    public HexCoordinates coordinates;

	public Color defaultColor = Color.white, highlightedColor = Color.magenta;

	public HexMetrics.TileType tileType;

    void Awake()
    {
		GetComponent<Renderer> ().material.color = defaultColor;
    }
}
