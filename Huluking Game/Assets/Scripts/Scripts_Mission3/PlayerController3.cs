using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController3 : MonoBehaviour {

	public GameObject obstacle;
	private float moveSpeed;
	private float angularSpeed;
	private bool skill;
	public Image backgroundImage;

	private VirtualJoystick joystick;
	//private int score;
	private bool restart;
	// Use this for initialization

	public void generateObstacles()
	{
		float minZ=-8.0f,maxZ=0.0f,minX=-5.0f,maxX=5.0f;
		int i = 0;
		for (;i<4;i++) {
			Instantiate(obstacle, new Vector3(UnityEngine.Random.Range(minX, 0.0f),1, UnityEngine.Random.Range(minZ, maxZ) ), Quaternion.identity);
		}
		for (i=0;i<4;i++) {
			Instantiate(obstacle, new Vector3(UnityEngine.Random.Range(0.0f,maxX),1, UnityEngine.Random.Range(minZ, maxZ) ), Quaternion.identity);
		}
	}

	void Start () {
		//score = 0;
		moveSpeed = 5.0f;
		angularSpeed=40.0f;
		skill = false;
		restart = false;
		//generateObstacles ();
	}


	public void setSpeed(float speed) {
		moveSpeed = speed;
	}

	public float getSpeed() {
		return moveSpeed;
	}

	public bool getSkill() {
		return skill;
	}

	public void setSkill(bool flag) {
		skill = flag;
	}

	public void setRestart(bool flag) {
		restart = flag;
	}

	void Update() {
		if (this.transform.position.y < -20)
			restart = true;
		if (restart) {
			int scene = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		joystick = backgroundImage.GetComponent<VirtualJoystick> ();
		float x = joystick.Horizontal() * Time.deltaTime * angularSpeed;
		transform.Rotate(0, x, 0);

		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.down * Time.deltaTime*angularSpeed);
			//Arrow.transform.Rotate(-1 * Vector3.down * Time.deltaTime * angularSpeed);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(Vector3.up * Time.deltaTime*angularSpeed);
			// Arrow.transform.Rotate(-1 * Vector3.up * Time.deltaTime * angularSpeed);
		}
		/*
		else if (Input.GetKey(KeyCode.Space))
		{
			skill = true;
			// Arrow.transform.Rotate(-1 * Vector3.up * Time.deltaTime * angularSpeed);
		}
		*/
		if (skill) {
			Renderer renderer = this.GetComponent<Renderer> ();
			renderer.material.SetColor ("_Color", Color.yellow);
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				moveSpeed = 30.0f;
				// Arrow.transform.Rotate(-1 * Vector3.up * Time.deltaTime * angularSpeed);
			} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
				moveSpeed = 5.0f;
				// Arrow.transform.Rotate(-1 * Vector3.up * Time.deltaTime * angularSpeed);
			}
		}


	}
}
