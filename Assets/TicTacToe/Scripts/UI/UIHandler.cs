using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour {

	public PlayerHandler myPlayer;
	GameHandler game;
	public Text myTeamText;
	
	void Awake()
	{
		myTeamText.gameObject.SetActive(true);
		game = myPlayer.game;
		game.OnChangeTurn += onChangeTurn;
		game.OnEndGame += onEndGame;
	}
	public void onChangeTurn(Team turn )
	{
		if(turn == myPlayer.myTeam)
		{
			myTeamText.text = "Your TURN.";
		}
		else
		{
			myTeamText.text = "Waiting on AI turn.";
		}

	}

	public void onEndGame(Team turn )
	{
		myTeamText.gameObject.SetActive(false);
	}
	public void PlayAgain()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
