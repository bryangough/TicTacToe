using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : PlayerBase {

	public UIHandler uiHandler;

	void Awake()
	{
		uiHandler.myPlayer = this;
	}
	public void touchSpot(Square square)
	{
		DoMove( square.x, square.y);
	}


	void Update () 
	{
		if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
		if( isYourTurn() && game.isGameActive )
		{
			Square square = null;
			//mobile
			#if UNITY_IOS || UNITY_ANDROID
				if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
				{
					RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
					if(hit.collider != null)
					{
						square = hit.collider.gameObject.GetComponent<Square>();
					}
				}
			#else
			//editor
				if( Input.GetMouseButtonDown(0) )
				{
					RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

					if(hit.collider != null)
					{
						square = hit.collider.gameObject.GetComponent<Square>();
						
					}
				}
			#endif
			if( square != null )
			{
				SquareModel model = game.getSquare(square.x, square.y);
				if( model!= null && model.team == Team.empty )
				{
					touchSpot(square);
				}
			}
		}
	}
}
