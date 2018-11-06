using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : PlayerBase {

	public AIEngine aIEngine;
	SquareModel squareModel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( isYourTurn() && game.isGameActive )
		{
			squareModel = aIEngine.DoCalculate(game.BoardModel);
			if(squareModel!=null)
			{
				DoMove( squareModel.x, squareModel.y);
			}
		}
	}
}		
		