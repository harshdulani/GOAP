using System.Collections.Generic;

public class ScaleDownAction : Action
{
	public ScaleDownAction()
	{
		Preconditions = new HashSet<KeyValuePair<string, object>>();
		Effects = new HashSet<KeyValuePair<string, object>>();
		
		AddPrecondition("myFatness", Fatness.Average | Fatness.Slim);
		AddPrecondition("myHeight", Height.Average | Height.Tall);
		AddEffect("myFatness", Fatness.Fat);
		AddEffect("myHeight", Height.Short);
	}
	
	//if you have to go to blue target, you have to be short, but short also makes you fat
	//pre condition
	public override void Perform(AgentController agent)
	{
		print("ScaledDown");
		
		agent.state.myFatness = Fatness.Fat;
		agent.state.myHeight = Height.Short;
		
		agent.MakeAgentShortAndFat(); 
	}
}