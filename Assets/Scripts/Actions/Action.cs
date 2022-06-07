using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
	public HashSet<KeyValuePair<string, object>> Preconditions;
	public HashSet<KeyValuePair<string, object>> Effects;

	public Transform Target { get; set; }

	public abstract void Perform(AgentController agent);
	
	protected void AddPrecondition(string variable, object desiredValue) => Preconditions.Add(new KeyValuePair<string, object>(variable, desiredValue));

	protected void AddEffect(string variable, object endValue) => Effects.Add(new KeyValuePair<string, object>(variable, endValue));

	protected static void print(object message) => Debug.Log(message);
}