using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	//public GameObject player;
	//private float speed;
	private Vector3 direction;
	private bool restart;
	private GameObject player;
	// Use this for initialization
	void Start () {
		//speed = 8.0f;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = this.GetComponent<Rigidbody> ();
		rb.velocity = (player.transform.position - transform.position) * 2.5f;
		Destroy (gameObject, 2.0f);
	}
	/*
	void OnCollisionEnter(Collision obj) {
		if(obj.gameObject.CompareTag("player"))
			Destroy(obj.gameObject);
	}
	*/
}