using UnityEngine;
using System.Collections;

public class BoardCtrl : MonoBehaviour {

    private int dir;
    private bool invoke;
    private Vector3 force;
    // Use this for initialization
    void Start () {
        dir = this.gameObject.name =="LeftBoard"?1:-1;
        invoke = false;
        force = dir == -1 ? Vector3.left : Vector3.right;
    }
	
	// Update is called once per frame
	void Update () {
        if (invoke) {
            if ((int)transform.position.y == 2) {

                dir = -1;
            }
            if ((int)transform.position.y == -4) {
                dir = 1;
            }
            transform.Translate(Vector3.up * Time.deltaTime * 2 * dir);
        }
    }
    void OnCollisionEnter(Collision obj)
    {
        Rigidbody r = obj.gameObject.GetComponent<Rigidbody>();
        
        r.AddForce(force * 20, ForceMode.Impulse);
       
    }
    void invokeBoard() {
        invoke = true;
    }
}
