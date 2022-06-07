using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentController : MonoBehaviour
{
	public AgentState state;
	
	[SerializeField] private Transform blueTarget, greenTarget, scaleDownTarget, scaleUpTarget;
	[SerializeField] private Button blueButton, greenButton, scaleDownButton, scaleUpButton;
	
	private Stack<Action> _currentActionPlan;
	
	private static BlueAction _blueAction;
	private static GreenAction _greenAction;
	private static ScaleDownAction _scaleDownAction;
	private static ScaleUpAction _scaleUpAction;
	private Action _currentAction;

	private Transform _transform, _mesh;

	public AgentMovement Movement { get; private set; }
	public PushdownAutomata Automata { get; private set; }

	private void Start()
	{
		Movement = GetComponent<AgentMovement>();
		Automata = GetComponent<PushdownAutomata>();

		_transform = transform;
		_mesh = _transform.GetChild(0);

		_currentActionPlan = new Stack<Action>();
		
		_blueAction = new BlueAction {Target = blueTarget};
		_greenAction = new GreenAction {Target = greenTarget};
		_scaleDownAction = new ScaleDownAction{Target = scaleDownTarget};
		_scaleUpAction = new ScaleUpAction{Target = scaleUpTarget};
		
		state = new AgentState { myHeight = Height.Average, myFatness = Fatness.Average};
	}

	public void PerformAction()
	{
		//don't make it perform action, tell the controller that one state has been popped from pushdown automata,
		//so it will also pop it from action plan stack
		_currentAction.Perform(this);
	}

	private void CreateActionPlan()
	{
		if(_currentAction == null) return;

		var targetPosition = _currentAction.Target.position;
		targetPosition.y = _transform.position.y;
		
		if(Vector3.Distance(targetPosition, _transform.position) > 0.01f)
			PushdownAutomata.CreateMoveState(this, targetPosition);
		else
		{
			PerformAction();
			SetCanvasStatus(true);
		}
	}

	public void MakeAgentAverageLooking()
	{
		_mesh.localScale = Vector3.one;
		_mesh.localPosition = Vector3.up;
		Movement.SetAgentHeight(2f);
		Movement.SetAgentRadius(0.5f);
	}

	public void MakeAgentShortAndFat()
	{
		_mesh.localScale = new Vector3(1.5f, 0.5f, 1.5f);
		//subtract minus half
		_mesh.localPosition = Vector3.up * 0.5f;
		Movement.SetAgentHeight(1f);
		Movement.SetAgentRadius(0.75f);
	}

	public void MakeAgentTallAndSlim()
	{
		_mesh.localScale = new Vector3(0.5f, 1.5f, 0.5f);
		//add plus half
		_mesh.localPosition = Vector3.up * 1.5f;
		Movement.SetAgentHeight(3f);
		Movement.SetAgentRadius(0.25f);
	}

	public void SetCanvasStatus(bool newStatus) => blueButton.interactable = greenButton.interactable = scaleDownButton.interactable = scaleUpButton.interactable = newStatus;

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

	public void PerformScaleDownAction()
	{
		print("scale Down Begin");

		_currentAction = _scaleDownAction;
		CreateActionPlan();
		SetCanvasStatus(false);
	}

	public void PerformScaleUpAction()
	{
		print("scale up Begin");

		_currentAction = _scaleUpAction;
		CreateActionPlan();
		SetCanvasStatus(false);
	}
}