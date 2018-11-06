using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler :MonoBehaviour {

	public delegate void BoardChangeDelegate(SquareModel model);
    public event BoardChangeDelegate OnBoardChange;

	public delegate void ChangeTurnDelegate(Team turn);
    public ChangeTurnDelegate OnChangeTurn;

	public delegate void EndGameDelegate(Team turn);
    public EndGameDelegate OnEndGame;


	//
	private SquareModel[] boardModel;
	public SquareModel[] BoardModel
	{
    	get { return boardModel; }
    	set { boardModel = value; }
	}
	public GameBoard gameBoard;
	public PlayerBase player1;
	public PlayerBase player2;
	public int numberOfPlays = 0;
	private Team turn = Team.empty;
	public Team Turn
	{
    	get { return turn; }
    	set 
		{ 
			turn = value; 
		}
	}

	int[,] winSpots = new int[,] { 
				{ 0, 1, 2 }, 
				{ 3, 4, 5 }, 
				{ 6, 7, 8 },
				{ 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
				{ 0, 4, 8 }, { 2, 4, 6 }
			};

	public bool isGameActive = false;

	void Awake()
	{
		if(player1 == player2)
		{
			 Debug.LogError("Both players cannont be the same object.");
		}
	}
	void Start()
	{
		createBoard();
		player1.setup(Team.blue, this);
		player2.setup(Team.red, this);
		//turn = Team.blue;
		RandomStartTeam();
		OnChangeTurn(turn);
		numberOfPlays = 0;
		isGameActive = true;
	}

	public void RandomStartTeam()
	{
		if(Random.value<0.5)
		{
			turn = Team.blue;
		}
		else
		{
			turn = Team.red;
		}
	}

	public void nextTurn()
	{
		numberOfPlays++;
		if(turn == Team.blue)
		{
			turn = Team.red;
		}
		else
		{
			turn = Team.blue;
		}
		//OnChangeTurn(turn);
		OnChangeTurn(turn);
	}


	void EndGame(Team winner)
	{
		OnEndGame(winner);
	}
    
	public void addPiece(int x, int y, Team team)
	{
		if(!isGameActive)
			return;
		SquareModel s = getSquare(x,y);
		if( s!=null && s.team==Team.empty )
		{
			s.team = turn;

			//Should this be an event?
			//gameBoard.AddMarker(s);
			OnBoardChange(s);
			//
			if( calculateIfWin(team) )
			{
				isGameActive = false;
				EndGame(team);
			}
			else
			{
				if(numberOfPlays>=8)
				{
					EndGame(Team.empty);
				}
				else
				{
					nextTurn();
				}
			}
		}
		else
		{
			Debug.Log("Error.");
		}
	}

	public SquareModel getSquare(int x, int y)
	{
		if(x>=0 && x<3 && y>=0 && y<3)
		{
			return boardModel[x+y*3];
		}
		return null;
	}
	void createBoard()
	{
		boardModel = new SquareModel[9];
		for(var y=0;y<3;y++)
		{
			for(var x=0;x<3;x++)	
			{
				boardModel[x+y*3] = new SquareModel(x, y);
			}
		}
	}

	public bool calculateIfWin(Team turn)
	{	
		//this is  lazy
		int count = 0;
		int length = winSpots.GetLength(0);
		for(var x = 0; x < length; x++)
		{
			count = 0;
			for( var y = 0; y < 3; y++)	
			{
				if( boardModel[ winSpots[x,y] ].team != turn )
				{
					break;
				}
				else
				{
					count++;
				}
			}
			if(count == 3)
			{
				return true;
			}
		}
		return false;
	}
}
