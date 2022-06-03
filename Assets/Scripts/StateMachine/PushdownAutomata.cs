using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PushdownAutomata : MonoBehaviour
{
	private static readonly IdleState IdleState = new IdleState();
	private static readonly Stack<AState> Stack = new Stack<AState>();

	private void Start()
	{
		Stack.Push(IdleState);
	}

	private void Update()
	{
		if(Stack.Peek().Execute()) return;

		Stack.Pop();
	}

	public static void CreateMoveState(AgentController agent, Vector3 position)
	{
		Stack.Push(new MoveState(agent, position));
	}

	private static bool HasTappedOverUi()
	{
		if (EventSystem.current) return EventSystem.current.IsPointerOverGameObject(-1);
		
		print("no event system"); return false;
	}
}