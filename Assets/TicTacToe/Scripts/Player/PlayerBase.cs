using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

	public GameHandler game;
	public Team myTeam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Use this for initialization
	public void DoMove(int x, int y)
	{
		if(game)
			game.addPiece(x,y, this.myTeam);
	}
	public void setup(Team team, GameHandler game)
	{
		this.game = game;
		this.myTeam = team;
	}

	public bool isYourTurn()
	{
		if(game)
		{
			return ( myTeam==game.Turn );
		}
		return false;
	}
}
