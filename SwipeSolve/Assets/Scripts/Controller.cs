using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Controller : MonoBehaviour{

	//Blocking Layer holds the objects we're intrested in colliding with
	public LayerMask blockingLayer;
	//For casting Rays, in order to predict coliisions
	protected static CircleCollider2D RedCircleCollider;
	protected static CircleCollider2D BlueCircleCollider;

	//To get the refferences to GameObjects so that we can determine whether they are at the same position or not
	public static GameObject BlueHole;
	public static GameObject RedHole;
	public static GameObject BlueBall;
	public static GameObject RedBall;
	public static Vector3 PredBlueLoc;
	public static Vector3 PredRedLoc;

	//For Balls to move
	private float RemainingDistance;
	private Vector3 babyStep;

	//For hitting the Objects with Ray beam from different positions
	private RaycastHit2D hit;
	private Vector2 start;
	protected Vector2 end;

	// Use this for initialization
	protected virtual void Start(){
		BlueHole = (GameObject) GameObject.FindGameObjectWithTag("BlueHole");
		RedHole = (GameObject) GameObject.FindGameObjectWithTag("RedHole");
		BlueBall = (GameObject) GameObject.FindGameObjectWithTag("BlueBall");
		PredBlueLoc = BlueBall.transform.position;
		RedBall = (GameObject) GameObject.FindGameObjectWithTag("RedBall");
		PredRedLoc = RedBall.transform.position;
	}

	//Predicting a Collision
	protected bool canMove(int x, int y, string identity){
		start = transform.position;
		end = start + new Vector2(x,y);
		//Because we're only intrested in disabling the collider of a specfic ball which actually invoked the Function
		if (identity == "RedPlayer")
			RedCircleCollider.enabled = false;
		else
			BlueCircleCollider.enabled = false;
		//Preparing to cast a ray from the position of the ball to the appropriate adjacent block
		hit = Physics2D.Linecast (start, end, blockingLayer);
		RedCircleCollider.enabled = true;
		BlueCircleCollider.enabled = true;
		//If It did not hit any object, give a green signal that the Ball can move
		if (hit.transform == null)
			return true;
		//If It collided with the other ball, disable the collider of that ball, 
		//and cast a ray from the position of that ball to determine whether that ball will move or not
		else if (hit.transform.tag == "RedBall" || hit.transform.tag == "BlueBall") {
			start = end;
			RedCircleCollider.enabled = false;
			BlueCircleCollider.enabled = false;
			hit = Physics2D.Linecast (start, (start + new Vector2 (x, y)), blockingLayer);
			RedCircleCollider.enabled = true;
			BlueCircleCollider.enabled = true;
			//If it doesn't hit any object that means that the ball will move, and we're good to move our ball to the position of other ball
			if (hit.transform == null)
				return true;
			else
				return false;
		}
		else return false;
	}

	//Transitioning the movement of Ball
	protected IEnumerator Move(Vector3 end){
		RemainingDistance = (transform.position - end).sqrMagnitude;
		while (RemainingDistance > float.Epsilon){
			//Making the transitions of Balls Frame independent by using Time.deltaTime
			babyStep = Vector3.MoveTowards(transform.position, end, 15 * Time.deltaTime);
			transform.position = babyStep;
			RemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
		GameManager.UpdateSwipes();
	}

	protected virtual void Update(){
		//Checking whether the Holes have consumed the Balls or not
		if (BlueHole.transform.position == BlueBall.transform.position && RedHole.transform.position == RedBall.transform.position && !GameManager.isGameOver){
			GameManager.GameOver();
			}
	}
}