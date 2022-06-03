[System.Serializable]
public struct AgentState
{
	public Height myHeight;
	public Fatness myFatness;
}

public enum Height { Short, Average, Tall };
public enum Fatness { Slim, Average, Fat }