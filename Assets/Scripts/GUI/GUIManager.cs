using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public Text tileInfo;
         
    public void WriteTileInfo(string info) {
        tileInfo.text = info;
    }
}
