using UnityEngine;
using System.Collections;

public class FloorNavDownwards : MonoBehaviour {
    private int height;
    private bool move;
    private Vector3 position;
    private float cnt;
	void Start () {
        move = false;
        position = transform.position;
        cnt = 0;

    }

    // Update is called once per frame
    void Update () {
		if ((int)transform.position.y!=21.0&& move) {
			transform.Translate(Vector3.down *1* Time.deltaTime);
			transform.Translate(Vector3.back * 4.9f * Time.deltaTime);
        }
        if ((int)transform.position.y == 21.0) {
           
            cnt+=Time.deltaTime;
        }
        if ((int)cnt == 3) {
            transform.position = position;
            cnt = 0;
            move = false;
        }
        
	}
    void OnCollisionEnter(Collision obj)
    {
        move = true;
    }
}
