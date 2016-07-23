using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

	public int width = 12;
	public int height = 12;

    public Color defaultColor = Color.white;
    public Color touchedcolor = Color.magenta;
    
    public HexCell cellPrefab;

    HexCell[] cells;

    public Text cellLabelPrefab;

    Canvas gridCanvas;



    void Awake() {
        gridCanvas = GetComponentInChildren<Canvas>();

        cells = new HexCell[height * width];

        int i = 0;

        for (int z = 0; z < height; z++) {
            for (int x = 0; x < width; x++) {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell (int x, int z, int i) {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeperateLines();
    }

    void Update()
    {
        //if (Input.GetMouseButton(0))
        HandleInput();
    }

	GameObject lastTouchedGameObject = null;

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit)){
			if (hit.collider.gameObject != lastTouchedGameObject) {
				if (lastTouchedGameObject != null) {
					Renderer rend = lastTouchedGameObject.GetComponent<Renderer>();
					rend.material.color = Color.white;
				}
			}

			TouchCell(hit.collider.gameObject);
        }
    }

	void TouchCell(GameObject touchedObject)
	{
		Renderer rend = touchedObject.GetComponent<Renderer>();
		rend.material.color = Color.magenta;
		lastTouchedGameObject = touchedObject;
    }
}