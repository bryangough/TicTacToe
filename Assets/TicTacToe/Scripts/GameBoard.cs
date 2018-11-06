using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//the graphic representation of the game
//the view
public class GameBoard : MonoBehaviour {

	public GameHandler game;
	public GameObject blueObject;
	public GameObject redObject;
	//
	public Square[] tiles;
	
	void Start()
	{
		game.OnBoardChange += AddMarker;
	}
	public Square getSquareFromTile(int x, int y)
	{
		if(x>=0 && x<3 && y>=0 && y<3)
		{
			return tiles[x+y*3];
		}
		return null;
	}
	
	public void AddMarker(SquareModel squareModel)
	{
		if( squareModel.team == Team.empty)
			return;
		GameObject prefab;
		if( squareModel.team == Team.blue)
		{
			prefab = blueObject;
		}
		else
		{
			prefab = redObject;
		}
		Square square = getSquareFromTile(squareModel.x, squareModel.y);
		GameObject piece = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
		piece.transform.position = square.transform.position;
		square.piece = piece;
	}
}
