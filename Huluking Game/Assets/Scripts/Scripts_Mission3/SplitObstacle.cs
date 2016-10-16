using UnityEngine;
using System.Collections;

public class SplitObstacle : MonoBehaviour {
	public GameObject player;
    private float topY = 5;
	private float bottomY = -2.0f;
    private float top = -1;
   
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (this.transform.position, player.transform.position);
		if (distance < 15.0f) {
			transform.Translate (Vector3.down * Time.deltaTime * top * 3);
			float tmpY = transform.position.y;
			if (tmpY > topY) {
				top = -1;
			}
			if (tmpY < bottomY) {
				top = 1;
			}
		}

	}
    void OnCollisionEnter(Collision coll)
    {

        Rigidbody r=coll.gameObject.GetComponent<Rigidbody>();
        r.AddForce(Vector3.up*15, ForceMode.Impulse);
    }
}
