using System;

[Serializable]
public struct AgentState
{
	public Height myHeight;
	public Fatness myFatness;
}

[Flags] public enum Height { Short = 1, Average = 2, Tall = 4 };
[Flags] public enum Fatness { Slim = 1, Average = 2, Fat = 4 }