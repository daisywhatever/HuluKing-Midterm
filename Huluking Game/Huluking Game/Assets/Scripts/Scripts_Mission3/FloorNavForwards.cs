using UnityEngine;
using System.Collections;

public class FloorNavForwards : MonoBehaviour {
    public GameObject target;
    // Use this for initialization
    private int width;
    private bool move;
    private float cnt;
    private Vector3 position;
	void Start () {
        move = false;
        cnt = 0;
        Mesh planeMesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;
        position = transform.position;
        // size in pixels
        
        float boundsZ = transform.localScale.z * bounds.size.z;
        width = (int)boundsZ/2;
    }

    // Update is called once per frame
    void Update () {
        if ((int)transform.position.z+width!=(int)target.transform.position.z && move) {
			transform.Translate(Vector3.forward *4.5f* Time.deltaTime);
        }
        if ((int)transform.position.z + width == (int)target.transform.position.z) {
            cnt += Time.deltaTime;
        }
        if ((int)cnt == 3) {
            transform.position = position;
            cnt = 0;
            move = false;
        }

    }
    void OnCollisionEnter(Collision obj)
    {
        move = true;
    }
}
