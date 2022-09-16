using System;

[Serializable]
public class GameTile {
    public string coord;
    public string tile;
}

[Serializable]
public class GameBoardData {
    public GameTile[] gameBoard;
}
