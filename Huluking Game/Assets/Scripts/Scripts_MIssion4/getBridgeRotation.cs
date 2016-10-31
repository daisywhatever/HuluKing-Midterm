using UnityEngine;
using System.Collections;

public class getBridgeRotation : MonoBehaviour {
	public GameObject bullet_shot_rotation;
	// Use this for initialization
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "bridge") {
			Debug.Log ("Test");
			bullet_shot_rotation.transform.rotation = other.gameObject.transform.rotation;
			//Debug.Log (bullet_shot_rotation.transform.rotation);
			//gameObject.transform.rotation.x = other.gameObject.transform.rotation.x;
		}
	}
}
