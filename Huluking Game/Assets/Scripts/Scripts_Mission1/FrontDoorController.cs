﻿using UnityEngine;
using System.Collections;

public class FrontDoorController : MonoBehaviour {

	public GameObject player;
	private PlayerController playerController;
	private bool flag;

	private float moveSpeedBK;

	// Use this for initialization
	void Start ()
	{
		flag = false;
		playerController = player.GetComponent<PlayerController> ();
		if (playerController == null) {
			Debug.Log ("PlayerController is null");
			return;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.y >= 18) {
			gameObject.SetActive (false);
			if (!flag) { 
				playerController.moveSpeed = moveSpeedBK;
				flag = true;
			}
		} else if (transform.position.y <= 0.5) {
			gameObject.SetActive (true);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		moveSpeedBK = playerController.moveSpeed;
		playerController.moveSpeed = 0;
	}
}
