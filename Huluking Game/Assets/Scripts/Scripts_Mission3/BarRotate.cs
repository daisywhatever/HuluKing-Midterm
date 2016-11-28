using UnityEngine;
using System.Collections;

public class BarRotate : MonoBehaviour {
	
	public GameObject player;
	//public float torque;
	//private Rigidbody rb;
	// Use this for initialization
	void Start () {
	//	rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.CompareTag ("pointer1")) {
			if (Vector3.Distance (this.transform.position, player.transform.position) < 40)
				transform.Rotate (Vector3.forward * Time.deltaTime * 60);
		} else if (gameObject.CompareTag ("pointer2")) {
			if (Vector3.Distance (this.transform.position, player.transform.position) < 40)
				transform.Rotate (Vector3.back * Time.deltaTime * 60);
		}
		else
        	transform.Rotate(Vector3.up * Time.deltaTime*25);

    }
	/*
	void onCollisionEnter(Collider other) {
		if(other.CompareTag("Player"))
			Destroy(other.gameObject);
	}
	*/


}
