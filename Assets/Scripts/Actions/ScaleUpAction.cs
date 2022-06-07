using System.Collections.Generic;

public class ScaleUpAction : Action
{
	public ScaleUpAction()
	{
		Preconditions = new HashSet<KeyValuePair<string, object>>();
		Effects = new HashSet<KeyValuePair<string, object>>();
		
		AddPrecondition("myFatness", Fatness.Average | Fatness.Fat);
		AddPrecondition("myHeight", Height.Average | Height.Short);
		AddEffect("myFatness", Fatness.Slim);
		AddEffect("myHeight", Height.Tall);
	}
	
	public override void Perform(AgentController agent)
	{
		print("ScaledUp");
		
		agent.state.myFatness = Fatness.Slim;
		agent.state.myHeight = Height.Tall;
		
		agent.MakeAgentTallAndSlim();
	}
}