using UnityEngine;
using System.Collections;

public class MoveObs : MonoBehaviour {

    private int leftEnd;
    private int leftStart;
    private int dir;
    private float speed;
    // Use this for initialization
    void Start () {
		leftEnd = (this.gameObject.name == "LeftOb") ? 196 : 182;
		//leftEnd = 196;
		leftStart = (this.gameObject.name == "LeftOb") ? 182 : 196;
        dir = this.gameObject.name=="LeftOb"? 1 : -1;
        speed = 4;
        //Destroy(this.gameObject, 20);
        
	}
	
	// Update is called once per frame
	void Update () {

		if ((int)transform.position.z >= leftEnd)
        {

			dir = -dir;
        } 
		if ((int)transform.position.z <= leftStart)
        {
            dir = -dir;
        } 

		transform.Translate(Vector3.right * speed * Time.deltaTime*dir);
		speed += 0.01f * Time.deltaTime;
	}
}
