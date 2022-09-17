using UnityEngine;

[System.Serializable]
public class HexCell : MonoBehaviour {

	public int x { get; private set; }
	public int z { get; private set; }
	public int y { get; private set; }

	public Vector3 position { get; set; } = Vector3.zero;

	public Color color;

	public void HexCoordinates( int _x, int _z ) {
		x = _x - _z / 2;
		z = _z;
		y = -x - z;
	}

	public string GetCoordString() {
		return $"{x},{y},{z}";
	}

}