using UnityEngine;
using System.Collections;

public class OpenTheDoor : MonoBehaviour {

    public GameObject leftGate;
    public GameObject rightGate;
    private bool move;
    // Use this for initialization
    void Start () {
        move = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 90*Time.deltaTime, 0));
        if (move) {
            if (leftGate != null && rightGate != null) {
                leftGate.transform.Translate(Vector3.left * Time.deltaTime * 10);
                rightGate.transform.Translate(Vector3.right * Time.deltaTime * 10);
            }
        }
    }
    void OnTriggerEnter()
    {
        move = true;
		//this.GetComponent<Renderer> ().enabled = false;
		//Destroy(this.gameObject,5.0f);
        Destroy(this.leftGate,2);
        Destroy(this.rightGate,2);

    }
}
