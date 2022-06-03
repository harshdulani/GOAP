using UnityEngine;

public class ScaleUp : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(!other.CompareTag("Agent")) return;
		
		if(!other.TryGetComponent(out AgentController agent)) return;

		agent.state.myFatness = Fatness.Slim;
		agent.state.myHeight = Height.Tall;
		
		agent.MakeAgentTallAndSlim();
	}
}