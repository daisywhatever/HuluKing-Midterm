using UnityEngine;
using System.Collections;

public class FoldSensorBarCtrl : MonoBehaviour
{
    public GameObject floorFront;
    public GameObject floorBack;
    // Use this for initialization
    void Start()
    {
		this.GetComponent<Renderer> ().enabled = false;
    }

    void OnTriggerEnter()
    {
        floorFront.SendMessage("invokeFloor");
        floorBack.SendMessage("invokeFloor");
        //Destroy(this.gameObject);
    }

}
