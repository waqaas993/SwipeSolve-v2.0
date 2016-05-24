using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {
	
	public int TileIndex;
	public string TileInformation;
    private static GameObject SelectedIngredient;

    void Awake() {
        SelectedIngredient = GameObject.Find("CurrIngred");
        SelectedIngredient.GetComponent<SpriteRenderer>().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
    }

    void OnMouseDown(){
			if (TileInformation == "")
				CreateLevel.DropIngredient(TileIndex);
			else{
				switch (TileInformation) {
				case "RedBall":
					CreateLevel.SelectedIngredient = "RedBall";
                    SelectedIngredient.GetComponent<SpriteRenderer>().sprite = Resources.Load("RedBall", typeof(Sprite)) as Sprite;
                    break;
				case "BlueBall":
					CreateLevel.SelectedIngredient = "BlueBall";
                    SelectedIngredient.GetComponent<SpriteRenderer>().sprite = Resources.Load("BlueBall", typeof(Sprite)) as Sprite;
                    break;
				case "BlueHole":
					CreateLevel.SelectedIngredient = "BlueHole";
                    SelectedIngredient.GetComponent<SpriteRenderer>().sprite = Resources.Load("BlueHole", typeof(Sprite)) as Sprite;
                    break;
				case "Obstacle":
					CreateLevel.SelectedIngredient = "Obstacle";
                    SelectedIngredient.GetComponent<SpriteRenderer>().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
                    break;
				case "RedHole":
					CreateLevel.SelectedIngredient = "RedHole";
                    SelectedIngredient.GetComponent<SpriteRenderer>().sprite = Resources.Load("RedHole", typeof(Sprite)) as Sprite;
                    break;
				case "Tile":
					CreateLevel.SelectedIngredient = "Tile";
                    SelectedIngredient.GetComponent<SpriteRenderer>().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
                    break;
				}
			}
	}
}