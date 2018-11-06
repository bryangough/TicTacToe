using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEngine : MonoBehaviour {
	//Adding a slight delay until the AI gives where their piece will be.
	//Setting this to 0 will make it instant
	public float ThinkingTime = 0.5f;
	public float timer = 0;
	void Start()
	{
		timer = ThinkingTime;
	}
	public SquareModel DoCalculate(SquareModel[] model)
	{
		timer-= Time.deltaTime;
		if(timer>0)
		{
			return null;
		}
		timer = ThinkingTime;
		//Is randomly selecting a random empty area
		List<SquareModel> squares = new List<SquareModel>();
		for(int x=0;x<model.Length;x++)
		{
			if(model[x].team==Team.empty)
			{
				squares.Add(model[x]);
			}
		}
		if(squares.Count<=0)
			return null;
		return  squares[Random.Range( 0, squares.Count )];
		
	}
}
