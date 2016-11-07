using UnityEngine;
using System.Collections;

public class PopUpSensorBar : MonoBehaviour {

    public Transform bomb1;
    public Transform bomb2;
    public GameObject popUp;
    // Use this for initialization
    void Start () {
		this.GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter() {
		Instantiate(popUp, bomb1.position, Quaternion.identity);
		Instantiate(popUp, bomb2.position, Quaternion.identity);
        Destroy(this.gameObject);

    }
}
