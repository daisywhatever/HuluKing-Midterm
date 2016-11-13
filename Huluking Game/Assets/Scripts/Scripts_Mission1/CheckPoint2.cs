using UnityEngine;
using System.Collections;

public class CheckPoint2 : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			PlayerController.stageIndex = 2;
		}
	}

}
