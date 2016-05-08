using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CreateLevel5x5 : MonoBehaviour {
	
	private static GameObject[] Blocks = new GameObject[25];
	public static string SelectedIngredient;

	private static bool RedBall;
	private static bool BlueBall;
	private static bool RedHole;
	private static bool BlueHole;


	void Awake(){

		RedBall = false;
		BlueBall = false;
		RedHole = false;
		BlueHole = false;


		for (int i = 0; i < 25; i++) {
			string tile = "Tile"+(i+1);
			Blocks[i] = GameObject.FindGameObjectWithTag(tile);				
		}

		SelectedIngredient = "Obstacle";
		
		for ( int i = 0 ; i < Blocks.Length ; i++)
			Blocks[i].GetComponent<Sprite>();
		
	}
	
	public static void DropIngredient(int TileIndex){
		switch (SelectedIngredient) {
		
		case "RedBall":
			if (!RedBall) {
				if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedBall", typeof(Sprite)) as Sprite;
					BlueBall = false;
					RedBall = true;
				}
				else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedBall", typeof(Sprite)) as Sprite;
					RedHole = false;
					RedBall = true;
				}
				else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedBall", typeof(Sprite)) as Sprite;
					BlueHole = false;
					RedBall = true;
				}
				else
				{
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedBall", typeof(Sprite)) as Sprite;
					RedBall = true;
				}
				break;
			}
			break;
		
		case "BlueBall":
			if (!BlueBall) {
				if(Resources.Load("RedBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueBall", typeof(Sprite)) as Sprite;
					RedBall = false;
					BlueBall = true;
				}
				else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueBall", typeof(Sprite)) as Sprite;
					RedHole = false;
					BlueBall = true;
				}
				else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueBall", typeof(Sprite)) as Sprite;
					BlueHole = false;
					BlueBall = true;
				}
				else
				{
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueBall", typeof(Sprite)) as Sprite;
					BlueBall = true;
				}
				break;
			}
			break;
		
		case "BlueHole":
			if (!BlueHole) {
				if(Resources.Load("RedBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueHole", typeof(Sprite)) as Sprite;
					RedBall = false;
					BlueHole = true;
				}
				else if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueHole", typeof(Sprite)) as Sprite;
					BlueBall = false;
					BlueHole = true;
				}
				else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueHole", typeof(Sprite)) as Sprite;
					RedHole = false;
					BlueHole = true;
				}
				else
				{
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueHole", typeof(Sprite)) as Sprite;
					BlueHole = true;
				}
				break;
			}
			break;
		
		case "Obstacle":
			if(Resources.Load("RedBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
				RedBall = false;
			}
			else if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
				BlueBall = false;
			}
			else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
				RedHole = false;
			}
			else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
				BlueHole = false;
			}
			else
			{
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
			}
			break;
		
		case "RedHole":
			if (!RedHole) {
				if(Resources.Load("RedBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedHole", typeof(Sprite)) as Sprite;
					RedBall = false;
					RedHole = true;
				}
				else if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedHole", typeof(Sprite)) as Sprite;
					BlueBall = false;
					RedHole = true;
				}
				else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedHole", typeof(Sprite)) as Sprite;
					BlueHole = false;
					RedHole = true;
				}
				else
				{
					Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedHole", typeof(Sprite)) as Sprite;
					RedHole = true;
				}
				break;
			}
			break;

		case "Tile":
			if(Resources.Load("RedBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
				RedBall = false;
			}
			else if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
				BlueBall = false;
			}
			else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
				RedHole = false;
			}
			else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
				BlueHole = false;
			}
			else
			{
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
			}
			break;
		}
	}
	
}