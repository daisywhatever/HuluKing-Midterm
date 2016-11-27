using UnityEngine;
using System.Collections;

public class LiftMachineController : MonoBehaviour {

	public GameObject player;
	private float speed;
	private PlayerController playerController;
	private float speedBK;
	private bool flag;
	private bool resetSpeed;

	// Use this for initialization
	void Start ()
	{
		flag = false;
		resetSpeed = false;
		speed = 0.2f;
		playerController = player.GetComponent<PlayerController> ();
		speedBK = playerController.moveSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flag) {
			if (player.transform.localScale.x == 4) {
				playerController.moveSpeed = 0;
				Animation animation = GetComponent<Animation> ();
				animation ["LiftControllerAnimation"].speed = speed;
				animation.Play ();
				flag = false;
			}
		}
		if (!resetSpeed) {
			if (transform.position.y >= 15 && player.transform.localScale.x == 1) {
				playerController.moveSpeed = speedBK;
				resetSpeed = true;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Player")) {
			flag = true;
		}
	}
}
