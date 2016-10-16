using UnityEngine;
using System.Collections;

public class FloorNavForwards : MonoBehaviour {
    public GameObject target;
    // Use this for initialization
    private int width;
    private bool move;
	void Start () {
        move = false;
       
        Mesh planeMesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;

        // size in pixels
        
        float boundsZ = transform.localScale.z * bounds.size.z;
        width = (int)boundsZ/2;
    }

    // Update is called once per frame
    void Update () {
        if ((int)transform.position.z+width!=(int)target.transform.position.z && move) {
			transform.Translate(Vector3.forward *4.5f* Time.deltaTime);
        }
	}
    void OnCollisionEnter(Collision obj)
    {
        move = true;
    }
}
