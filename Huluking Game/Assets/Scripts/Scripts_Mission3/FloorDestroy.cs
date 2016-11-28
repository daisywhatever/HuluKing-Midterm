using UnityEngine;
using System.Collections;

public class FloorDestroy : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Vector3.Distance (this.transform.position, player.transform.position) < 25)
			Destroy (this.gameObject);
	}
}
