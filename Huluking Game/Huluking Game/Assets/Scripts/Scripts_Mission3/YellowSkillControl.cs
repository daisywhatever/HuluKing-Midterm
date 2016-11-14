using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class YellowSkillControl : MonoBehaviour, IPointerDownHandler {
	public GameObject player;
	private PlayerController3 playerController;
	private Image skillImg;
	private bool flag;
	// Use this for initialization
	void Start () {
		//Debug.Log ("111");
		flag = false;
		skillImg = GetComponent<Image> ();
		playerController = player.GetComponent<PlayerController3> ();
	}

	// Update is called once per frame
    
	void YellowSkill () {
		if (playerController.getSkill ()) {
			//Debug.Log ("success");
			if (flag) {
				playerController.setSpeed (30.0f);
				flag = false;
			} else {
				playerController.setSpeed (5.0f);
				flag = true;
			}
		} else
			Debug.Log ("fail");
	}
    
	public virtual void OnPointerDown(PointerEventData ped)
	{
		//Debug.Log ("success");
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (skillImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			//Debug.Log ("success");
			YellowSkill();
		}

	}
    /*
    public virtual void OnPointerUp(PointerEventData ped)
	{
		playerController.setSpeed (5.0f);

	}
	*/
}
