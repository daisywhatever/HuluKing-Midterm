using UnityEngine;
using System.Collections;

public class ObsRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        transform.Rotate(Time.deltaTime*20*Vector3.forward);
	}
	void onCollisionEnter(Collider other) {
		if(other.CompareTag("Player"))
			Destroy(other.gameObject);
	}
}
