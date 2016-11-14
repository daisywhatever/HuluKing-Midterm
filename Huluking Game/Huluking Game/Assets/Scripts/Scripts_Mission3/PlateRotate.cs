using UnityEngine;
using System.Collections;

public class HorizontalRotate : MonoBehaviour {

    private float speed;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
  
       

    }
    public void setSpeed(float speed) {
        this.speed = speed;
    }
}
