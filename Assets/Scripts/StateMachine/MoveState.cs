using UnityEngine;

public sealed class MoveState : AState
{
	private readonly AgentController _agent;
	private RaycastHit _myHit;
	private bool _waitForMakingNavMeshPath = true; 

	public MoveState(AgentController agent, Vector3 destination)
	{
		_agent = agent;
		_agent.Movement.SetMoveDestination(destination);
	}

	public override bool Execute()
	{
		if (_waitForMakingNavMeshPath)
		{
			_waitForMakingNavMeshPath = false;
			return true;
		}
		
		if (_agent.Movement.HasReachedDestination())
		{
			_agent.PerformAction();
			return false;
		}
		
		return true;
	}
}