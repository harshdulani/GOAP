using UnityEngine;

public abstract class AState
{
	//Must return true when you want to stay in this state in the next frame also,
	//return false when work here is done
	public abstract bool Execute();

	protected static void print(object message) => Debug.Log(message);
}