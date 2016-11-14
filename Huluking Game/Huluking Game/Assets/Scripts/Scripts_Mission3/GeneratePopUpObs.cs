using UnityEngine;
using System.Collections;

public class GeneratePopUpObs : MonoBehaviour {

    public GameObject popUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter()
    {
        Instantiate(popUp, transform.position + new Vector3(3.0f,-2.5f,1.0f),Quaternion.identity);
        Destroy(this.gameObject);
    }
}
