using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private PlayerController3 playerController;
	public GameObject endingImage;
	public Text countText;
	private int count;
	//private int count;
	void Start() {
		playerController = this.GetComponent<PlayerController3> ();
		count = 0;
		countText.text = "Count: " + count.ToString ();
		//count = 0;
	}
	void OnCollisionEnter(Collision obj)
	{

        //Debug.Log("collide with "+ obj.gameObject.name);
        if (obj.gameObject.CompareTag("stone")) {
			if (playerController.getSpeed() == 30.0f) {
				obj.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right*10, ForceMode.Impulse);
			}
		}
		if (obj.gameObject.CompareTag ("coin")) {
			count++;
			countText.text = "Count: " + count.ToString ();
			Destroy (obj.gameObject);
		}
		if (obj.gameObject.CompareTag ("skill")) {
			playerController.setSkill (true);
			Destroy (obj.gameObject);
		}
        if (obj.gameObject.CompareTag("obstacle"))
        {
            
            playerController.setRestart(true);
        }
        /*
		if (obj.gameObject.CompareTag ("door")) {
			Debug.Log (count);
			if (playerController.getSpeed () == 30.0f)
				count++;
			if (count == 3)
				Destroy (obj.gameObject);
		}
		*/
        if (obj.gameObject.name== "PopUpObs(Clone)")
        {
            playerController.setRestart(true);
        }
        if (obj.gameObject.CompareTag ("bar"))
			playerController.setRestart (true); 
		if (obj.gameObject.CompareTag ("rail"))
			this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,105.7f);
		if (obj.gameObject.name=="Bullet(Clone)") {
			//Debug.Log ("collide with bullet.");
			playerController.setRestart (true); 
		}
        
        if (obj.gameObject.CompareTag ("yellowDoor")) {
			//Debug.Log ("HI");
			endingImage.SetActive (true);
			Time.timeScale = 0;
		}
		if (obj.gameObject.CompareTag ("otherDoor")) {
			playerController.setRestart (true);
		}
		if (obj.gameObject.CompareTag ("pointer1") || obj.gameObject.CompareTag ("pointer2"))
			playerController.setRestart (true); 
	}
}
