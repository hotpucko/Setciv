using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HexGrid : MonoBehaviour {

	public int width = 12;
	public int height = 12;
	public HexCell[] cellPrefabs;
	public HexCell waterPrefab;

    //public HexCell cellPrefab;

    //HexCell[] cells;

    public Text cellLabelPrefab;
	List<HexCell> cells;

    void Awake() {
		cells = new List<HexCell> ();//HexCell[height * width];

		//CreateHexGrid ();
		CreateSquareGridWithWater ();
    }

	void CreateSquareGrid() {
		for (int z = 0; z < height; z++) {
			for (int x = 0; x < width; x++) {
				CreateSquareCell(x, z);
			}
		}
	}

	void CreateSquareGridWithWater() {
		for (int z = 0; z < height; z++) {
			for (int x = 0; x < width; x++) {
				CreateSquareCell (x, z);

				//water
				CreateWaterCell (x, z - height);//bottom
				CreateWaterCell (x, z + height);//top
				CreateWaterCell (x - width, z);//left
				CreateWaterCell (x + width, z);//right

				CreateWaterCell (x - width, z - height);//bottom left
				CreateWaterCell (x + width, z - height);//bottom right
				CreateWaterCell (x - width, z + height);//top left
				CreateWaterCell (x + width, z + height);//top right
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

		cell.transform.rotation = GetRandomRotation (cell.transform.rotation);

        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

        /*Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
		label.transform.position.Set(label.transform.position.x, 3, label.transform.position.z);
        label.text = cell.coordinates.ToStringOnSeperateLines();*/
    }

	void CreateWaterCell(int x, int z) {
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = Instantiate<HexCell> (waterPrefab);

		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
	}

	Quaternion GetRandomRotation(Quaternion rotation){
		Vector3 euler = rotation.eulerAngles;
		int amountToRotate = UnityEngine.Random.Range (0, 6);
		euler = new Vector3 (euler.x, euler.y + amountToRotate * 60, euler.z);
		return Quaternion.Euler (euler);
	}


	HexCell GetRandomCellPrefab(){
		return cellPrefabs[UnityEngine.Random.Range (0, cellPrefabs.Length)];
	}
}