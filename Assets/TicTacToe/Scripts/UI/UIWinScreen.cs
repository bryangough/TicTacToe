using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWinScreen : MonoBehaviour {

	public Text finalMessage;
	public PlayerHandler myPlayer;
	GameHandler game;
	
	void Awake()
	{
		game = myPlayer.game;
		game.OnEndGame += onEndGame;
		this.gameObject.SetActive(false);
	}

	public void onEndGame(Team turn )
	{
		this.gameObject.SetActive(true);

		if(turn == myPlayer.myTeam)
		{
			finalMessage.text = "You Win.";
		}
		else if(turn == Team.empty)
		{
			finalMessage.text = "Draw game.";
		}
		else 
		{
			finalMessage.text = "You lose.";
		}
		

	}
}
