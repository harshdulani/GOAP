using UnityEngine;

public abstract class Action
{
	public abstract Transform Target { get; set; }
	
	//target hoga ek
	//target distance
	
	public abstract bool Perform();
	
	protected static void print(object message) => Debug.Log(message);
}

public class BlueAction : Action
{
	public override Transform Target { get; set; }

	public override bool Perform()
	{
		print("Blue");
		return false;
	}
}

public class GreenAction : Action
{
	public override Transform Target { get; set; }

	public override bool Perform()
	{
		print("Green");
		return false;
	}
}