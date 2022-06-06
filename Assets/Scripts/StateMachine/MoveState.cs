using UnityEngine;

public sealed class MoveState : AState
{
	private readonly AgentController _agent;
	private RaycastHit _myHit;

	private readonly Vector3 _dest;
	private bool _waitForMakingNavMeshPath = true;

	public MoveState(AgentController agent, Vector3 destination)
	{
		_agent = agent;
		_dest = destination;
		_agent.Movement.SetMoveDestination(_dest);
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
			Debug.DrawLine(_agent.transform.position, _dest, Color.red, 2f, false);
			if ((_agent.transform.position - _dest).magnitude < 0.1f)
			{
				_agent.PerformAction();
				_agent.SetCanvasStatus(true);
			}
			else
			{
				print("Didn't Reach Pos");
				_agent.SetCanvasStatus(true);
			}
			return false;
		}
		
		return true;
	}
}