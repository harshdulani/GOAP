using UnityEngine;

public class ScaleDown : MonoBehaviour
{
	/*
	 public void GetScaledDown(AgentController agent)
	{
		agent.state.myFatness = Fatness.Fat;
		agent.state.myHeight = Height.Short;
		
		agent.MakeAgentShortAndFat(); 
	}*/
	
	private void OnTriggerEnter(Collider other)
	{
		if(!other.CompareTag("Agent")) return;
		
		if(!other.transform.parent.TryGetComponent(out AgentController agent)) return;

		agent.state.myFatness = Fatness.Fat;
		agent.state.myHeight = Height.Short;
		
		agent.MakeAgentShortAndFat(); 
	}
}