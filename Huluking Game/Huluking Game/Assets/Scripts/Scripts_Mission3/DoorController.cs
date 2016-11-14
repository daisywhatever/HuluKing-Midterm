using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision obj)
	{
		if(obj.gameObject.CompareTag("Player")) {
			Rigidbody r = obj.gameObject.GetComponent<Rigidbody>();
			r.AddForce(Vector3.left*4, ForceMode.Impulse);
            Destroy(this.gameObject, 5);
		}
	}


}
