using UnityEngine;
using System.Collections;

public class BackwardForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnCollisionEnter(Collision obj) {
        Rigidbody r = obj.gameObject.GetComponent<Rigidbody>();
		r.AddForce(Vector3.back * 5.5f, ForceMode.Impulse);
    }
}
