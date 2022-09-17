using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

	public int width = 7;
	public int height = 7;

	public Color defaultColor = Color.blue;
	public Color homeColor = Color.green;

	public HexCell cellPrefab;
	public Text cellLabelPrefab;

	List<HexCell> cells;

	Canvas gridCanvas;
	HexMesh hexMesh;
	GameBoardData gameBoardData;

	void Awake () {
		gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new List<HexCell>();

		//This centers the grid around central hex
        int xStart = (int)( width / 2 );
		int xStop = width - xStart;

        int zStart = (int)( height / 2 );
		int zStop = height - zStart;

		//Get the gameboard layout
		TextAsset jsonFile = Resources.Load<TextAsset>( "gameBoard_3p" );
        gameBoardData = JsonUtility.FromJson<GameBoardData>( jsonFile.text );

		for (int z = -zStart; z < zStop; z++) {
			for (int x = -xStart; x < xStop; x++) {
                HexCell cell = Instantiate<HexCell>( cellPrefab );
                cell.HexCoordinates( x, z );
                foreach ( GameTile tile in gameBoardData.gameBoard ) {
					if ( tile.coord == cell.GetCoordString() ) {
						cell.position = GetHexPosition( x, z );
						CreateCell( cell );
						SetCellLabel( cell, tile.tile );
						SetCellColor( cell );
                        cells.Add(cell);
                    }
				}
				/*
				if ( cell.position == Vector3.zero ) {
                    cell.position = GetHexPosition( x, z );
                    CreateCell( cell );
                    SetCellLabel( cell, cell.GetCoordString() );
                    SetCellColor( cell );
                    cells.Add( cell );
                }
				*/
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

	void CreateCell( HexCell cell ) {
		cell.transform.SetParent( transform, false );
		cell.transform.localPosition = cell.position;
	}

	void SetCellLabel(HexCell cell, string lblText) {
		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition = new Vector2(cell.position.x, cell.position.z);
		label.text = lblText;
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