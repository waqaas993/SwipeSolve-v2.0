using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CreateLevel : MonoBehaviour {

    int BoardSize;
    private static GameObject[] Blocks;
	public static string SelectedIngredient;

	private static bool RedBall;
	private static bool BlueBall;
	private static bool RedHole;
	private static bool BlueHole;
    private static JsonSchema JsonObject;
    public static string JsonString;


    void Awake(){
        JsonObject = new JsonSchema();
        BoardSize = PlayerPrefs.GetInt("CurrentLevelEditor");
        Blocks = new GameObject[BoardSize * BoardSize];

        RedBall = false;
		BlueBall = false;
		RedHole = false;
		BlueHole = false;


		for (int i = 0; i < (BoardSize*BoardSize); i++) {
			string tile = "Tile"+(i+1);
			Blocks[i] = GameObject.Find(tile);				
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
                        JsonObject.BlueBall = 100;
                        BlueBall = false;
                        RedBall = true;
				}
				else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                        Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedBall", typeof(Sprite)) as Sprite;
                        JsonObject.RedHole = 100;
                        RedHole = false;
                        RedBall = true;
				}
				else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                        Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedBall", typeof(Sprite)) as Sprite;
                        JsonObject.BlueHole = 100;
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
                        JsonObject.RedBall = 100;
                        RedBall = false;
                        BlueBall = true;
				}
				else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                        Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueBall", typeof(Sprite)) as Sprite;
                        JsonObject.RedHole = 100;
                        RedHole = false;
                        BlueBall = true;
				}
				else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                        Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueBall", typeof(Sprite)) as Sprite;
                        JsonObject.BlueHole = 100;
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
                        JsonObject.RedBall = 100;
                        RedBall = false;
                        BlueHole = true;
				}
				else if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                        Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueHole", typeof(Sprite)) as Sprite;
                        JsonObject.BlueBall = 100;
                        BlueBall = false;
                        BlueHole = true;
				}
				else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                        Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("BlueHole", typeof(Sprite)) as Sprite;
                        JsonObject.RedHole = 100;
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
                    JsonObject.RedBall = 100;
                    RedBall = false;
			}
			else if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                    Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
                    JsonObject.BlueBall = 100;
                    BlueBall = false;
			}
			else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                    Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
                    JsonObject.RedHole = 100;
                    RedHole = false;
			}
			else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                    Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Obs", typeof(Sprite)) as Sprite;
                    JsonObject.BlueHole = 100;
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
                        JsonObject.RedBall = 100;
                        RedBall = false;
                        RedHole = true;
				}
				else if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                        Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedHole", typeof(Sprite)) as Sprite;
                        JsonObject.BlueBall = 100;
                        BlueBall = false;
                        RedHole = true;
				}
				else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                        Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("RedHole", typeof(Sprite)) as Sprite;
                        JsonObject.BlueHole = 100;
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
                    JsonObject.RedBall = 100;
                    RedBall = false;
			}
			else if(Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                    Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
                    JsonObject.BlueBall = 100;
                    BlueBall = false;
			}
			else if(Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                    Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
                    JsonObject.RedHole = 100;
                    RedHole = false;
			}
			else if(Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[TileIndex].GetComponent<SpriteRenderer>().sprite){
                    Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
                    JsonObject.BlueHole = 100;
                    BlueHole = false;
			}
			else
			{
				Blocks[TileIndex].GetComponent<SpriteRenderer> ().sprite = Resources.Load("Block", typeof(Sprite)) as Sprite;
			}
			break;
		}
	}



    public void GenerateMapData() {
        BoardSize = PlayerPrefs.GetInt("CurrentLevelEditor");
        JsonObject.BoardSize = BoardSize;
        JsonObject.Obstacles.Clear();
        for (int i = 0; i < (BoardSize * BoardSize); i++){
            if (Resources.Load("RedBall", typeof(Sprite)) as Sprite == Blocks[i].GetComponent<SpriteRenderer>().sprite)
                JsonObject.RedBall = i;
            else if (Resources.Load("BlueBall", typeof(Sprite)) as Sprite == Blocks[i].GetComponent<SpriteRenderer>().sprite)
                JsonObject.BlueBall = i;
            else if (Resources.Load("RedHole", typeof(Sprite)) as Sprite == Blocks[i].GetComponent<SpriteRenderer>().sprite)
                JsonObject.RedHole = i;
            else if (Resources.Load("BlueHole", typeof(Sprite)) as Sprite == Blocks[i].GetComponent<SpriteRenderer>().sprite)
                JsonObject.BlueHole = i;
            else if (Resources.Load("Obs", typeof(Sprite)) as Sprite == Blocks[i].GetComponent<SpriteRenderer>().sprite)
            {
                if (!JsonObject.Obstacles.Contains(i))
                    JsonObject.Obstacles.Add(i);
            }                
        }
        JsonString = JsonUtility.ToJson(JsonObject);
        Debug.Log(JsonString);
    }
}