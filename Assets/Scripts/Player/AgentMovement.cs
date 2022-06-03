using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentMovement : MonoBehaviour
{
	public NavMeshAgent _navMover;

	private void Start()
	{
		_navMover = GetComponent<NavMeshAgent>();
	}

	public void SetMoveDestination(Vector3 position) => _navMover.SetDestination(position);

	public bool HasReachedDestination() => _navMover.remainingDistance <= 0.01f;
}