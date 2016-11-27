using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

	public static int stageIndex = 0;

	public Vector3[] resetPoints;
	public Quaternion[] resetAngles;
	public Camera cam;
	public Text countText;
	public GameObject endingImage;

	public float moveSpeed;
	public float rotateSpeed;
	public Image backgroundImage;

	private int resetLocationIndex = 0;
	private bool restart;
	private VirtualJoystick joystick;
	private Renderer rend;
	private float jumpPower = 550;
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
		if (joystick == null) {
			Debug.Log ("joystick is null");
			return;
		}
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		count = 0;
		countText.text = "Score: " + count.ToString ();

		transform.position = resetPoints [stageIndex];
		transform.Rotate(0, resetAngles[stageIndex].y, 0);
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

		if (Input.GetKeyUp (KeyCode.Space)) {
			RedSkill ();
		}

		if (transform.position.y < -10) {
			restart = true;
		}

		if (restart) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
		/*
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * moveSpeed);
		*/
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Coin")) {
			Destroy (other.gameObject);
			count = count + 1;
			countText.text = "Score: " + count.ToString ();
		} else if (other.gameObject.CompareTag ("Cap_Obstacle")) {
			restart = true;
		} else if (other.gameObject.CompareTag ("Bullet")) {
			restart = true;
		} else if (other.gameObject.CompareTag ("redDoor")) {
			endingImage.SetActive (true);
			stageIndex = 0;
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
		} else if (collision.gameObject.CompareTag ("Stone")) {
			restart = true;
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

	/*
	void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
		bf.Serialize (file, stageIndex);
		file.Close ();
	}

	void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			stageIndex = (int)bf.Deserialize(file);
			file.Close();
		}
	}
	*/
}