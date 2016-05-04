using UnityEngine;
using System.Collections;
using System;



public class RedPlayer : Controller {

	//For Swipes Detections
	private Vector2 fingerStart;
	private Vector2 fingerEnd;

	// Use this for initialization
	protected override void Start () {
		RedCircleCollider = GetComponent<CircleCollider2D>();
		base.Start ();
	}

	//For Keyboard Inputs
	// Update is called once per frame
	protected new void Update() {
		if (!GameManager.isGameOver) {
			if (Input.GetKeyDown ("up")){
				if (canMove (0, 1, "RedPlayer")){ 
					StartCoroutine (Move (end));
				}
			}
			else if (Input.GetKeyDown ("down")){
				if (canMove (0, -1, "RedPlayer"))
					StartCoroutine (Move (end));
			}
			else if (Input.GetKeyDown ("left")){
				if (canMove (-1, 0, "RedPlayer")){
					StartCoroutine (Move (end));
				}
			}
			else if (Input.GetKeyDown ("right")){
				if (canMove (1, 0, "RedPlayer")){
					StartCoroutine (Move (end));
				}
			}
		}
	}
	/*
	//For Android Inputs
	// Update is called once per frame
	protected new void Update() {
		if (!GameManager.isGameOver) {
			foreach(Touch touch in Input.touches){
				if (touch.phase == TouchPhase.Began){
					fingerStart = touch.position;
					fingerEnd  = touch.position;
				}
				if (touch.phase == TouchPhase.Moved ){
					fingerEnd = touch.position;

				}
				if(touch.phase == TouchPhase.Ended){
					if((fingerStart.x - fingerEnd.x) > 75 ){		//Swipe Left
						if (canMove (-1, 0, "RedPlayer"))
							StartCoroutine (Move (end));
					}
					else if((fingerStart.x - fingerEnd.x) < -75){	//Swipe Right
						if (canMove (1, 0, "RedPlayer"))
							StartCoroutine (Move (end));
					}
					else if((fingerStart.y - fingerEnd.y) < -75){	//Swipe Up
						if (canMove (0, 1, "RedPlayer"))
							StartCoroutine (Move (end));
					}
					else if((fingerStart.y - fingerEnd.y) > 75){	//Swipe Down
						if (canMove (0, -1, "RedPlayer"))
							StartCoroutine (Move (end));
					}

				}				
			}
		}
	}*/
}