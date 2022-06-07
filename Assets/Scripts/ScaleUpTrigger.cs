using UnityEngine;

public class ScaleUpTrigger : MonoBehaviour
{
	[SerializeField] private GameObject gateDoor;

	private void OnTriggerEnter(Collider other)
	{
		if(!other.CompareTag("Agent")) return;
		
		gateDoor.SetActive(false);
	}
}