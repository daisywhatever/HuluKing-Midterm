using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class YellowSkillControl : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
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
    void Update()
    {

    }
   
    
	public  void OnPointerDown(PointerEventData ped)
	{
		
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (skillImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
           
            if (playerController.getSkill()) { 
                playerController.setSpeed(30.0f);
            }
		}

	}
   

    public void OnPointerUp(PointerEventData ped)
    {
        Vector2 pos;
       
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(skillImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            playerController.setSpeed(5.0f);
        }
    }
}
