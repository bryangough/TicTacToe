[System.Serializable]
public class SquareModel
{
	public SquareModel(int x, int y, Team team)
	{
		this.x = x;
		this.y = y;
		this.team = team;
	}
	public SquareModel(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	public int x;
	public int y;
	public Team team;
};
