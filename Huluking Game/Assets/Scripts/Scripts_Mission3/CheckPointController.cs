using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void OnTriggerEnter() {
		
		PlayerController3 controller = player.GetComponent<PlayerController3> ();
		controller.setCheckPoint(this.GetComponent<Collider>());
	}
}
