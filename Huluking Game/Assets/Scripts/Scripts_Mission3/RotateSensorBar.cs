using UnityEngine;
using System.Collections;

public class RotateSensorBar : MonoBehaviour {

    public GameObject board;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter()
    {
        board.SendMessage("invokeBoard");

        Destroy(this.gameObject);

    }
}
