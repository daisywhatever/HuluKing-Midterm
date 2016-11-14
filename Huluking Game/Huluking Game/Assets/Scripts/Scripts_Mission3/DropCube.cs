using UnityEngine;
using System.Collections;

public class DropCube: MonoBehaviour {

    public GameObject dropCube;
	//private Renderer renderer;
    // Use this for initialization
    void Start () {
		this.GetComponent<Renderer>().enabled = false;
      //  body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter() {
        generateDropCube();
		Destroy (this.gameObject);
    }
    void generateDropCube() {
		Quaternion rotation = Quaternion.Euler(0, 90, 0);
		Instantiate(dropCube, transform.position+new Vector3(5.0f,1.0f,-4.0f), rotation);
		Instantiate(dropCube, transform.position+new Vector3(5.0f,1.0f,0), rotation);
		Instantiate(dropCube, transform.position+new Vector3(5.0f,1.0f,4.0f), rotation);
    }
}
