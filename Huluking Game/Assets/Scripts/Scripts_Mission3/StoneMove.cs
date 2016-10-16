using UnityEngine;
using System.Collections;

public class StoneMove : MonoBehaviour {

	//private Rigidbody rb;
	// Use this for initialization
	void Start () {
		//rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision obj)
	{
		if(obj.gameObject.CompareTag("Player")) {
			Rigidbody r = obj.gameObject.GetComponent<Rigidbody>();
			r.AddForce(Vector3.left*15, ForceMode.Impulse);
		}
	}
}
