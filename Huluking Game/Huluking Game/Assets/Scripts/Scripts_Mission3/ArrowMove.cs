using UnityEngine;
using System.Collections;

public class ArrowMove : MonoBehaviour {



    private Transform tracking;
    private Transform center;
    Transform pivot;

    // Use this for initialization
    void Start()
    {
        center=GameObject.Find("Cube").transform;
        tracking=GameObject.Find("Exit").transform;
        pivot = transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        pivot.position = center.position+new Vector3(0,1,3);
        Vector3 revise=new Vector3(tracking.position.x,center.position.y,tracking.position.z);
        var dist = Vector3.Distance(center.position, transform.position);
      
        pivot.LookAt(revise);
        transform.position = center.position + pivot.forward * dist;
        transform.LookAt(revise);
        transform.parent = pivot;
        //pivot.LookAt(tracking);
    }

}
