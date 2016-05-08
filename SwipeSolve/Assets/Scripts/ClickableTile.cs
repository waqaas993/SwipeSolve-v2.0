using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {
	
	public int TileIndex;
	public string TileInformation;
	
	void OnMouseDown(){
		if(Application.loadedLevelName == "CustomCreateLevel5x5"){
			if (TileInformation == "")
				CreateLevel5x5.DropIngredient(TileIndex);
			else{
				switch (TileInformation) {
				case "RedBall":
					CreateLevel5x5.SelectedIngredient = "RedBall";
					break;
				case "BlueBall":
					CreateLevel5x5.SelectedIngredient = "BlueBall";
					break;
				case "BlueHole":
					CreateLevel5x5.SelectedIngredient = "BlueHole";
					break;
				case "Obstacle":
					CreateLevel5x5.SelectedIngredient = "Obstacle";
					break;
				case "RedHole":
					CreateLevel5x5.SelectedIngredient = "RedHole";
					break;
				case "Tile":
					CreateLevel5x5.SelectedIngredient = "Tile";
					break;
				}
			}
		} else
			if (Application.loadedLevelName == "CustomCreateLevel6x6")
			{
				if (TileInformation == "")
				CreateLevel6x6.DropIngredient(TileIndex);
				else{
					switch (TileInformation) {
					case "RedBall":
						CreateLevel6x6.SelectedIngredient = "RedBall";
						break;
					case "BlueBall":
						CreateLevel6x6.SelectedIngredient = "BlueBall";
						break;
					case "BlueHole":
						CreateLevel6x6.SelectedIngredient = "BlueHole";
						break;
					case "Obstacle":
						CreateLevel6x6.SelectedIngredient = "Obstacle";
						break;
					case "RedHole":
						CreateLevel6x6.SelectedIngredient = "RedHole";
						break;
					case "Tile":
						CreateLevel6x6.SelectedIngredient = "Tile";
						break;
				}
			}
		}
	}
}