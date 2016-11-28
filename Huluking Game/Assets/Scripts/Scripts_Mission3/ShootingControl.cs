using UnityEngine;
using System.Collections;

public class ShootingControl : MonoBehaviour {

	public GameObject player;
	public GameObject bullet;
	private float interval;
	private float nextShot;
	// Use this for initialization
	void Start () {
		interval = 0.5f;
		nextShot = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (this.transform.position, player.transform.position);
		if (distance < 15 && this.transform.position.z >= player.transform.position.z) {
			nextShot += Time.deltaTime;
			//StartCoroutine (Shooting());
			if (nextShot > interval) {
				Instantiate (bullet, this.transform.position, Quaternion.identity);
				nextShot = 0;
			}
		}
	}
/*	
	IEnumerator Shooting() {
		while (true) {
			Instantiate (bullet, transform.position-new Vector3(0,1.0f,0), Quaternion.identity);
			yield return new WaitForSeconds (interval);
		}
	}
*/
}
