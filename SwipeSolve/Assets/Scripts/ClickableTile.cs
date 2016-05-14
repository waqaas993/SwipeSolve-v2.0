using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {
	
	public int TileIndex;
	public string TileInformation;
	
	void OnMouseDown(){
			if (TileInformation == "")
				CreateLevel.DropIngredient(TileIndex);
			else{
				switch (TileInformation) {
				case "RedBall":
					CreateLevel.SelectedIngredient = "RedBall";
					break;
				case "BlueBall":
					CreateLevel.SelectedIngredient = "BlueBall";
					break;
				case "BlueHole":
					CreateLevel.SelectedIngredient = "BlueHole";
					break;
				case "Obstacle":
					CreateLevel.SelectedIngredient = "Obstacle";
					break;
				case "RedHole":
					CreateLevel.SelectedIngredient = "RedHole";
					break;
				case "Tile":
					CreateLevel.SelectedIngredient = "Tile";
					break;
				}
			}
	}
}