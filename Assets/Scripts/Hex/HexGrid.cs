using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HexGrid : MonoBehaviour {

	public int width = 12;
	public int height = 12;

    public Color defaultColor = Color.white;
    public Color touchedcolor = Color.magenta;
    
	public HexCell[] cellPrefabs;

    //public HexCell cellPrefab;

    //HexCell[] cells;

    public Text cellLabelPrefab;

    Canvas gridCanvas;

	List<HexCell> cells;

	public Text testText;


    void Awake() {
        gridCanvas = GetComponentInChildren<Canvas>();

		cells = new List<HexCell> ();//HexCell[height * width];

		//CreateHexGrid ();
		CreateSquareGrid ();
    }

	void CreateSquareGrid() {
		for (int z = 0; z < height; z++) {
			for (int x = 0; x < width; x++) {
				CreateSquareCell(x, z);
			}
		}
	}

	void CreateHexGrid() {
		for (int z = 0; z < height; z++) {
			for (int x = 0; x < width - z / 2; x++) {
				CreateHexCell (new Vector3 ((x + z * 0.5f - z / 2) * HexMetrics.innerRadius * 2f, 0f, z * (HexMetrics.innerRadius * 1.5f)));
			}
		}
	}

	void CreateHexCell(Vector3 position) {
		/*HexCell cell = Instantiate<HexCell> (cellPrefab);
		cells.Add (cell);

		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(1, 1);
		cell.tileType = HexMetrics.GetRandomTileType ();

		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
		label.text = cell.coordinates.ToStringOnSeperateLines();*/
	}

    void CreateSquareCell (int x, int z) {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = Instantiate<HexCell>(GetRandomCellPrefab());
		cells.Add (cell);

        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
		label.transform.position.Set(label.transform.position.x, 3, label.transform.position.z);
        label.text = cell.coordinates.ToStringOnSeperateLines();
    }

    void Update()
    {
        HandleInput();
    }

	HexCell GetRandomCellPrefab(){
		return cellPrefabs[UnityEngine.Random.Range (0, cellPrefabs.Length)];
	}

	HexCell lastTouchedGameObject = null;
    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
		Renderer rend;
        if (Physics.Raycast(inputRay, out hit)){
			HexCell touchedGameObject = hit.collider.gameObject.GetComponent<HexCell>();

			if (touchedGameObject != lastTouchedGameObject) {
				if (lastTouchedGameObject != null) {
					rend = lastTouchedGameObject.GetComponent<Renderer>();
					rend.material.color = lastTouchedGameObject.defaultColor;
				}
			}
			rend = touchedGameObject.GetComponent<Renderer>();
			rend.material.color = touchedGameObject.highlightedColor;
			lastTouchedGameObject = touchedGameObject;

			if(Input.GetMouseButton(0))
				TouchCell(hit.collider.gameObject);
        }
    }

	void TouchCell(GameObject touchedObject)
	{
		HexCell hexCell = touchedObject.GetComponent<HexCell> ();

		testText.text = hexCell.tileType.ToString ();//"X: " + hexCell.coordinates.X + ", Y: " + hexCell.coordinates.Y + ", Z: " + hexCell.coordinates.Z;
		//Hud.setselectedobjecttext()
		//touchedObject.GetComponent<HexCoordinates> ().X = 1000f;
    }
}