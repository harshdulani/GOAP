using UnityEngine;
using UnityEngine.UI;

public class AgentController : MonoBehaviour
{
	[SerializeField] private Transform blueTarget, greenTarget;
	[SerializeField] private Button action1, action2;

	private static BlueAction _blueAction;
	private static GreenAction _greenAction;
	
	private Action _currentAction;
	private Transform _transform;

	public AgentMovement Movement { get; private set; }
	public PushdownAutomata Automata { get; private set; }

	private void Start()
	{
		Movement = GetComponent<AgentMovement>();
		Automata = GetComponent<PushdownAutomata>();

		_transform = transform;

		_blueAction = new BlueAction {Target = blueTarget};
		_greenAction = new GreenAction {Target = greenTarget};
	}

	public void PerformAction()
	{
		_currentAction.Perform();
		SetCanvasStatus(true);
	}

	private void SetCanvasStatus(bool newStatus) => action1.interactable = action2.interactable = newStatus;

	private void CreateActionPlan()
	{
		if(_currentAction == null) return;
		
		if(Vector3.Distance(_currentAction.Target.position, _transform.position) > 0.01f)
			PushdownAutomata.CreateMoveState(this, _currentAction.Target.position);
		else
			PerformAction();
	}
	
	public void PerformBlueAction()
	{
		print("blue begin");
		
		_currentAction = _blueAction;
		CreateActionPlan();
		SetCanvasStatus(false);
	}

	public void PerformGreenAction()
	{
		print("green begin");
		
		_currentAction = _greenAction;
		CreateActionPlan();
		SetCanvasStatus(false);
	}
}