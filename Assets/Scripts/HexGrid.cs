using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

	public int width = 7;
	public int height = 7;

	public Color defaultColor = Color.white;
	public Color homeColor = Color.green;

	public HexCell cellPrefab;
	public Text cellLabelPrefab;

	HexCell[] cells;

	Canvas gridCanvas;
	HexMesh hexMesh;
	GameBoardData gameBoardData;

	void Awake () {
		gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new HexCell[height * width];

		//This centers the grid around central hex
        int xStart = (int)( width / 2 );
		int xStop = width - xStart;

        int zStart = (int)( height / 2 );
		int zStop = height - zStart;

		//Get the gameboard layout
		TextAsset jsonFile = Resources.Load<TextAsset>( "gameBoard_3p" );
        gameBoardData = JsonUtility.FromJson<GameBoardData>( jsonFile.text );

		for (int z = -zStart, i = 0; z < zStop; z++) {
			for (int x = -xStart; x < xStop; x++) {
				Vector3 pos = GetHexPosition( x, z);
				cells[i] = CreateCell(pos);
				Debug.Log( cells[ i ] );
				cells[i].HexCoordinates( x, z );
				SetCellLabel( cells[ i ] );
				SetCellColor( cells[ i ] );
				i++;
			}
		}
	}

	void Start () {
		hexMesh.Triangulate(cells);
	}

	Vector3 GetHexPosition( int x, int z ) {
        Vector3 position;
        position.x = ( x + z * 0.5f - z / 2 ) * ( HexMetrics.innerRadius * 2f );
        position.y = 0f;
        position.z = z * ( HexMetrics.outerRadius * 1.5f );
		return position;
    }

	HexCell CreateCell( Vector3 position ) {
		HexCell cell = Instantiate<HexCell>( cellPrefab );
		cell.transform.SetParent( transform, false );
		cell.transform.localPosition = position;
		cell.position = position;
		return cell;
	}

	void SetCellLabel(HexCell cell) {
		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition = new Vector2(cell.position.x, cell.position.z);
		label.text = cell.x.ToString() + "\n" + cell.y.ToString() + "\n" + cell.z.ToString();
	}

	void SetCellColor(HexCell cell) {
		cell.color = defaultColor;
		foreach ( GameTile tile in gameBoardData.gameBoard ) {
			if ( tile.coord == cell.GetCoordString()) {
				if ( tile.tile.Contains("home") ) {
					cell.color = homeColor;
				}
			}
		}
	}
}