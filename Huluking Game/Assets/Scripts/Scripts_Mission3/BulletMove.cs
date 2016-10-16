using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	//public GameObject player;
	private float speed;
	private Vector3 direction;
	private bool restart;
	private GameObject player;
	// Use this for initialization
	void Start () {
		speed = 8.0f;
		player = GameObject.Find ("Player");
		//direction = Vector3.back;
		//direction = new Vector3(player.transform.position.x-this.transform.position.x,
		//						player.transform.position.y-this.transform.position.y,
		//						player.transform.position.z-this.transform.position.z);
								
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = this.GetComponent<Rigidbody> ();
		rb.velocity = (player.transform.position - transform.position) * 2;
		Destroy (gameObject, 2.0f);
	}
	/*
	void OnCollisionEnter(Collision obj) {
		if(obj.gameObject.CompareTag("player"))
			Destroy(obj.gameObject);
	}
	*/
}