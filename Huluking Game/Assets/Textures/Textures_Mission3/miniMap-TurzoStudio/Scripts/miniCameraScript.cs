using UnityEngine;
using System.Collections;

public class miniCameraScript : MonoBehaviour {


	public Transform MiniMapTarget;


	void Update(){


	}

	void LateUpdate () {

		transform.position = new Vector3 (MiniMapTarget.position.x, MiniMapTarget.position.y+5,MiniMapTarget.position.z);
		transform.eulerAngles = new Vector3( transform.eulerAngles.x, MiniMapTarget.eulerAngles.y, transform.eulerAngles.z );

	}
}