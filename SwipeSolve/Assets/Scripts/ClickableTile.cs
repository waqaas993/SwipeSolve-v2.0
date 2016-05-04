using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {

	public int TileX;
	public int TileY;
	public string TileInformation;

	void OnMouseUp(){
		if (TileInformation == "")
			Debug.Log("Tile Clicked" + TileX +  TileY);
		else{
			Debug.Log("Switch Called");
			switch (TileInformation) {
			case "RedBall":
				Debug.Log("RedBall");
				break;
			case "BlueBall":
				Debug.Log("BlueBall");
				break;
			case "BlueHole":
				Debug.Log("BlueHole");
				break;
			case "Obstacle":
				Debug.Log("Obstacle");
				break;
			case "RedHole":
				Debug.Log("RedHole");
				break;
			case "Tile":
				Debug.Log("Tile");
				break;
			}
		}
	}

	/*
	void OnTouchDown(){
		//do code stuff when finger has touched down on screen
	}
	void OnTouchUp(){
		//do other touch code but when pulling finger off of touchscreen
	}
	void OnTouchDrag(){
		///do code stuff when you drag your finger. could even be OnTouchMove instead
	}
	*/
}