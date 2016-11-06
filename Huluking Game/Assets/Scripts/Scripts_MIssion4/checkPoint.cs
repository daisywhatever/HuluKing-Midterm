using UnityEngine;
using System.Collections;

public class checkPoint : MonoBehaviour {
    static public Vector3 reachedPoint = new Vector3(0f, 0.66f, -19f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        //Mission4_Player_Controller Player = (Mission4_Player_Controller)GameObject.Find("Playerobject").GetComponent("Mission4_Player_Controller");
       // Player.currentCheckPoint = this;
        if (col.gameObject.CompareTag("Player"))
        {
            reachedPoint = transform.position;
        }
    } 
}
