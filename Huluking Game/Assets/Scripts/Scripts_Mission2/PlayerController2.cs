using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PlayerController2 : MonoBehaviour {

	public GameObject cam;
	public Text countText;
	public GameObject endingImage;

	public float moveSpeed;
	public float rotateSpeed;
	public Image backgroundImage;

	private bool restart;
	private VirtualJoystick joystick;
	private Renderer rend;
	private float jumpPower = 450;
	private Rigidbody rb;
	private bool jumpFlag;
	private bool upFlag;
	private bool downFlag;
	private bool flag = false;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		restart = false;
		jumpFlag = false;
		downFlag = false;
		upFlag = false;
		joystick = backgroundImage.GetComponent<VirtualJoystick> ();
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		count = 0;
		countText.text = "Score: " + count.ToString ();
	}

	void Update()
	{

		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
		var x = joystick.Horizontal() * Time.deltaTime * rotateSpeed;
		transform.Rotate(0, x, 0);
		// var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
		// var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		// transform.Translate(0, 0, z);

		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

		if (jumpFlag && transform.localScale.x == 1) {
			rb.AddForce (Vector3.up * jumpPower);
			if (transform.position.y >= 1) {
				jumpFlag = false;
			}
		}

		if (upFlag) {

			if (transform.position.y >= 0) {
				upFlag = false;
			}
		}

		if (downFlag) {

			//cam.transform.position =  Vector3 (1, 0.5, 1);
			if (transform.position.y <= -8) {
				//cam.transform.position = position;
				downFlag = false;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			RedSkill ();
		}

		if (transform.position.y < -10) {
			restart = true;
		}

		if (restart) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Coin")) {
			Destroy (other.gameObject);
			count = count + 1;
			countText.text = "Score: " + count.ToString ();


		} else if (other.gameObject.CompareTag ("Cap_Obstacle")) {
			// collide effect
			/* ++++++ */
			restart = true;
		} else if (other.gameObject.CompareTag ("Bullet")) {
			/* ++++++ */
			restart = true;
		} else if (other.gameObject.CompareTag ("redDoor")) {
			endingImage.SetActive (true);
			Time.timeScale = 0;
		} else if (other.gameObject.CompareTag ("otherDoor")) {
			restart = true;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Jump_Plane")) {
			if (transform.localScale.x == 4) {

				Destroy (collision.gameObject);
			} else {
				jumpFlag = true;
			}
		} else {
			// audio.Play ();
		}
		if (collision.gameObject.CompareTag ("Upground")) { 
			upFlag = true;
		}
		if (collision.gameObject.CompareTag ("Downground")) {
			downFlag = true;
		}
	}

	void RedSkill()
	{
		

		Vector3 position = cam.transform.position;
		if (flag) {
			transform.localScale = new Vector3 (1, 1, 1);
			flag = false;
		} else {
			transform.localScale = new Vector3 (4, 4, 4);
			flag = true;
		}
		cam.transform.position = position;
	}
}