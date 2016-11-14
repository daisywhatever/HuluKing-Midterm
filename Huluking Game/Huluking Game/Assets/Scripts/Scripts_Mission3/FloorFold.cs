using UnityEngine;
using System.Collections;

public class FloorFold : MonoBehaviour {

    private int degree;
    private bool invoke;
    private Vector3 rotate;
	// Use this for initialization
	void Start () {
        degree = this.gameObject.name == "testFloorFront" ?330:30;
        rotate = degree == 330 ? Vector3.left :Vector3.right;

	}
	
	// Update is called once per frame
	void Update () {
        
        if (invoke&&(int)transform.eulerAngles.x!=degree) {
            transform.Rotate(rotate * Time.deltaTime * 20);
        }
	}
    void invokeFloor() {
        invoke = true;
    }
}
