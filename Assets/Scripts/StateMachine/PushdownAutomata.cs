using System.Collections.Generic;
using UnityEngine;

public class PushdownAutomata : MonoBehaviour
{
	private static readonly IdleState IdleState = new IdleState();
	private static readonly BlockState BlockState = new BlockState();
	private static readonly FiringState FiringState = new FiringState();

	private static readonly Stack<AState> Stack = new Stack<AState>();

	private void Start()
	{
		Stack.Push(IdleState);
	}


	private void Update()
	{
		var newState = HandleInput();
		
		if (newState != null && newState != Stack.Peek()) 
			Stack.Push(newState);

		if(Stack.Peek().Execute()) return;

		Stack.Pop();
	}

	private AState HandleInput()
	{
		if(Stack.Count > 1) return null;
		
		if (Input.GetMouseButton(0))
			return FiringState;
		if (Input.GetMouseButton(1))
			return BlockState;

		return null;
	}

	private static void PopStateMachine() => Stack.Pop();
}

public abstract class AState
{
	//Must return true when you want to stay in this state in the next frame also,
	//return false when work here is done
	public abstract bool Execute();

	protected static void print(object message) => Debug.Log(message);
}

public class IdleState : AState
{
	public override bool Execute()
	{
		print("Idle");
		return true;
	}
}

public class BlockState : AState
{
	public override bool Execute()
	{
		print("Block");
		
		if(Input.GetMouseButton(1)) return true;

		return false;
	}
}

public class FiringState : AState
{
	public override bool Execute()
	{
		print("Firing");
		
		if(Input.GetMouseButton(0)) return true;
		
		return false;
	}
}