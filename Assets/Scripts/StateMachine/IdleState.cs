public class IdleState : AState
{
	public override bool Execute()
	{
		print("Idle");
		return true;
	}
}