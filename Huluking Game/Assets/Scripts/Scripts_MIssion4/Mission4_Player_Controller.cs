using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Mission4_Player_Controller : MonoBehaviour {

	public GameObject cam;
	public GameObject endingImage;
    public Collider currentCheckPoint;

	public float moveSpeed;
	public float rotateSpeed;
	public Image backgroundImage;
	public Material greenMaterial;
	public Image skillButton;


	private bool restart;
	private M4_VirtualJoystick joystick;
	private Renderer rend;

	private bool bridge_rotate_flag = false;
	private int bridge_rotate_count = 0;
	public GameObject bridge_rotate_1;
	public GameObject bridge_rotate_2;
	public GameObject bridge_rotate_3;

	public GameObject coin_audio;


	public GameObject bridge_rotation;

	private Vector3 move_direction;
	private float pos_y = 0.0f;
	private bool up = false;
	void Start()
	{
		skillButton.color = Color.green;
		move_direction = new Vector3 (0.0f, 0.0f, 1.0f);
		restart = false;
		joystick = backgroundImage.GetComponent<M4_VirtualJoystick> ();
		if (joystick == null) {
			Debug.Log ("joystick is null");
			return;
		}
		if (skillButton == null) {
			Debug.Log ("skillButton is null");
			return;
		}
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
        transform.position = checkPoint.reachedPoint;
        if (transform.position.z != -19f)
        {
            skillButton.color = Color.green;
            rend.sharedMaterial = greenMaterial;
        }
	}

	void Update()
	{
		if (gameObject.transform.position.y > pos_y) {
			up = true;
		} else {
			up = false;
		}

		pos_y = gameObject.transform.position.y;
		if (bridge_rotate_flag) {
			rotate_bridge ();
			bridge_rotate_count++;
			if (bridge_rotate_count == 120) {
				bridge_rotate_flag = false;
				bridge_rotate_count = 0;
			}
		} else {
			Debug.Log (up + ": "+move_direction);
			transform.Translate (move_direction * Time.fixedDeltaTime * moveSpeed);
			var y = joystick.Horizontal () * Time.fixedDeltaTime * rotateSpeed;
			transform.Rotate (0, y, 0);
			transform.Translate (move_direction * Time.fixedDeltaTime * moveSpeed);
		}


		if (transform.position.y < -10) {
			restart = true;
		}

		if (restart) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
           // transform.position = checkPoint.reachedPoint;
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Coin")) {
			Destroy (other.gameObject);
		}else if (other.gameObject.CompareTag ("Hulu")) {
			rend.sharedMaterial = greenMaterial;
			skillButton.color = Color.green;
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Obstacle")) {
			restart = true;
		} else if (other.gameObject.CompareTag ("Rotate_point")) {
			Destroy (other.gameObject);
			bridge_rotate_flag = true;
		} else if (other.gameObject.CompareTag ("Coin4")) {
			AudioSource audio = coin_audio.GetComponent<AudioSource> ();
			audio.Play ();
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("greenDoor")) {
			endingImage.SetActive (true);
			Time.timeScale = 0;
		} else if (other.gameObject.CompareTag ("otherDoor")) {
			restart = true;
		}
	}

	void rotate_bridge(){
		var x =Time.fixedDeltaTime * 20;
		transform.Rotate (0, x, 0);
		bridge_rotate_1.transform.Rotate (0, x, 0);
		bridge_rotate_2.transform.Rotate (0, x, 0);
		bridge_rotate_3.transform.Rotate (0, x, 0);
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "bridge") {
			bridge_rotation.transform.rotation = other.gameObject.transform.rotation;
			if (bridge_rotation.transform.rotation.x < 0 && up) {
				move_direction = new Vector3 (0.0f, 0.4129f, 1.0f);
			} else {
				move_direction = new Vector3 (0.0f, 0.0f, 1.0f);
			}
			//bullet_shot_rotation.transform.rotation = other.gameObject.transform.rotation;
			//Debug.Log (bullet_shot_rotation.transform.rotation);
			//gameObject.transform.rotation.x = other.gameObject.transform.rotation.x;
		}
	}

}
