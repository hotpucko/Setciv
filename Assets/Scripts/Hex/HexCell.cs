using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexCell : MonoBehaviour {

    public HexCoordinates coordinates;

    public Color color;

    void Awake()
    {
        //Color[] colors = GetComponent<MeshFilter>().mesh.colors;
        //List<Color> cols = new List<Color>();
        //for (int i = 0; i < colors.Length; i++)
        //{
        //    cols.Add(Color.magenta);
        //}
        //colors = cols.ToArray();
    }

}
