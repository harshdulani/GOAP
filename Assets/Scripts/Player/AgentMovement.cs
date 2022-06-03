using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentMovement : MonoBehaviour
{
	private NavMeshAgent _navMover;

	private void Start()
	{
		_navMover = GetComponent<NavMeshAgent>();
	}

	public void SetMoveDestination(Vector3 position) => _navMover.SetDestination(position);

	public bool HasReachedDestination() => _navMover.remainingDistance <= 0.01f;

	public void SetAgentHeight(float height) => _navMover.height = height;
	public void SetAgentRadius(float radius) => _navMover.radius = radius;
}