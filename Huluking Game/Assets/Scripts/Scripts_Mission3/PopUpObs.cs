using UnityEngine;
using System.Collections;

public class PopUpObs : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
       
        if (transform.position.y <= 21.0f)
        {
            transform.Translate(Vector3.up*Time.deltaTime*2);
        }
	}
    
}
