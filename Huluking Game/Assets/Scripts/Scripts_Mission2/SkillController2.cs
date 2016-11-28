using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SkillController2 : MonoBehaviour,IPointerDownHandler {

	public GameObject player;
	public PlayerController playController;
	public ParticleSystem ps;
	private Image skillImg;
	private bool flag;

	// Use this for initialization
	private void Start() {
		flag = false;
		skillImg = GetComponent<Image> ();
		ps.Stop ();
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

	public virtual void OnPointerDown(PointerEventData ped)
	{
		RedSkill ();
	}
}
