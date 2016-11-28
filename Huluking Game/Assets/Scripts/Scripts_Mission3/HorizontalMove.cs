using UnityEngine;
using System.Collections;

public class HorizontalMove : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.back *Time.deltaTime * 3.0f);
		Destroy (this.gameObject, 5);
	}
}
