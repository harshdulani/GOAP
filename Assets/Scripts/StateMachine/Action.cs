using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
	/*
	public HashSet<KeyValuePair<Enum, object>> Preconditions;
	public HashSet<KeyValuePair<Enum, object>> Effects;
	*/
	
	public Transform Target { get; set; }

	public abstract void Perform();
	
	protected static void print(object message) => Debug.Log(message);
}

public class ScaleDownAction : Action
{
	public override void Perform()
	{
		print("scaled down");
	}
}

public class BlueAction : Action
{
	//if you have to go to blue target, you have to be short, but short also makes you fat
	//pre condition
	public override void Perform()
	{
		print("Blue");
	}
}

public class GreenAction : Action
{
	//if you want to go to green target, you have to be slim, but slim also makes you tall
	public override void Perform()
	{
		print("Green");
	}
}