using UnityEngine;
using System.Collections;

public class Text_moving : MonoBehaviour {
	private int move_right;
	public int cur_pos;
	public float moveSpeed;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (cur_pos == 10)
			move_right = 1;
		if (cur_pos == 0)
			move_right = 0;
		if (move_right == 1) {
			gameObject.transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
			cur_pos--;
		} else {
			gameObject.transform.Translate (-Vector3.right * Time.deltaTime * moveSpeed);
			cur_pos++;
		}
	}
}
