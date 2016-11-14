using UnityEngine;
using System.Collections;

public class PlatformRotate1: MonoBehaviour {

    
    
    
    // Use this for initialization
    void Start () {
       
        
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20);
       

    }
   

    
    void OnCollisionEnter(Collision coll)
    {


       Rigidbody  r = coll.gameObject.GetComponent<Rigidbody>();
       
		r.AddForce(Vector3.right *3.0f, ForceMode.Impulse);
		r.AddForce(Vector3.back *5.0f, ForceMode.Impulse);

        //r.AddTorque(transform.position, ForceMode.Impulse);
    }
}
