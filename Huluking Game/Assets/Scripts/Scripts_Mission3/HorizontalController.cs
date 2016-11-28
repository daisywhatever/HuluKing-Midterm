using UnityEngine;
using System.Collections;

public class HorizontalController: MonoBehaviour {

    public GameObject horizontalObj;
    //private float speed;
	// Use this for initialization
	void Start () {
      //  speed = 1f;
		this.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
       
        }
    void OnTriggerEnter()
    {
        for (int i = 0; i < 3; i++)
        {
           
			Instantiate(horizontalObj, transform.position+new Vector3(5+4*i, 1.0f,3*i), Quaternion.identity);
            //float speed = 20/(i+6);
            //go.GetComponent<HorizontalRotate>().setSpeed(speed);
            //Destroy(go, i*2);
        }

    }
}
