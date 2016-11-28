using UnityEngine;
using System.Collections;

public class FloorRotate : MonoBehaviour {

	public GameObject player;
	Quaternion rotation = Quaternion.identity;
	private int direction;

	void Start()
	{
		direction = 1;
		rotation.eulerAngles = new Vector3 (0, 0, 30);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (this.transform.position, player.transform.position) < 40) {
			transform.Rotate (Vector3.forward * Time.deltaTime * 8 * direction);

			//Debug.Log (transform.rotation.eulerAngles.z);
			//Debug.Log (rotation.eulerAngles.z);
			if (transform.rotation.eulerAngles.z > 30) {
				direction = -1;
			}
			if (transform.rotation.eulerAngles.z > 330)
				direction = 1;
		}
	}
}
