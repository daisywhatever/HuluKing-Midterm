using UnityEngine;
using System.Collections;

public class FloorNavDownwards : MonoBehaviour {
    private int height;
    private bool move;
	void Start () {
        move = false;
    }

    // Update is called once per frame
    void Update () {
		if ((int)transform.position.y!=21.0f && move) {
			transform.Translate(Vector3.down *1* Time.deltaTime);
			transform.Translate(Vector3.back * 4.9f * Time.deltaTime);
        }
	}
    void OnCollisionEnter(Collision obj)
    {
        move = true;
    }
}
