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
	public ParticleSystem ps;

	private bool restart;
	private VirtualJoystick joystick;
	private Renderer rend;
	private float jumpPower = 450;
	private Rigidbody rb;
	private bool jumpFlag;
	private bool flag = false;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		restart = false;
		jumpFlag = false;
		joystick = backgroundImage.GetComponent<VirtualJoystick> ();
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		count = 0;
		countText.text = "Score: " + count.ToString ();
		flag = false;
		ps.Stop ();
	}

	void Update()
	{

		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
		var x = joystick.Horizontal() * Time.deltaTime * rotateSpeed;
		transform.Rotate(0, x, 0);

		transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

		if (jumpFlag && transform.localScale.x == 1) {
			rb.AddForce (Vector3.up * jumpPower);
			if (transform.position.y >= 1) {
				jumpFlag = false;
			}
		}



		if (Input.GetKeyUp (KeyCode.Space)) {
			RedSkill ();
		}

		
		if (transform.position.y < -10) {
			restart = true;
		}

		if (restart) {
			Debug.Log ("HERE");
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
			restart = true;
		} else if (other.gameObject.CompareTag ("Bullet")) {
			//Debug.Log ("BUllet");
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
		} else if (collision.gameObject.CompareTag ("mountain")){
			Debug.Log ("HELLO");
			restart = true;
		}
	}

	void RedSkill()
	{
		if (flag) {
			ps.Stop ();
			flag = false;
		} else {
			ps.Play ();
			flag = true;
		}
	}
}