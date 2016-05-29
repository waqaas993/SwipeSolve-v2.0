using UnityEngine;
using System;  //to use serializeable attribute
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class CustomLoadLevel : MonoBehaviour 
{
	//Maze size m*n
	private int rows;
	private int columns;

	//Prefabs
	public GameObject redBall;
	public GameObject blueBall;
	public GameObject redHole;
	public GameObject blueHole;
	public GameObject Wall;
	public GameObject Obstacle;
	public GameObject floorTile;
	public Camera MainCamera;

	//Deciding a Tile to place on Board
	private GameObject toInstantiate;
	//To keep hierarchy clean for board and level
	private Transform boardHolder;
	private Transform levelHolder;
	//To keep a static copy of generated tile instance so that we can child it to above parents
	private GameObject instance;

    private JsonSchema JsonObject;


    //Constructing Levels
    public void SetupScene()
    {
        JsonObject = new JsonSchema();
        JsonObject = JsonUtility.FromJson<JsonSchema>(PlayerPrefs.GetString("MapData"));
        rows = JsonObject.BoardSize;
        columns = JsonObject.BoardSize;
        BoardSetup();
        if (JsonObject.BoardSize == 5)
            FiveByFiveCameraSettings();
        else
            SixBySixCameraSettings();
        SpawnLevelComponents();
    }

    void BoardSetup (){
        boardHolder = new GameObject("Board").transform;
		for (int x =-1; x <= columns; x++){
			for (int y =-1; y <= rows; y++){
				//Decide a tile for Floor tile from 4 given sprites based on the random function
				toInstantiate = floorTile;
				//If it's the border, instialize it with an invisible border
				if(x==-1 || x == columns || y==-1 || y == rows)
					toInstantiate = Wall;
				instance = Instantiate(toInstantiate, new Vector3(x,y,0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(boardHolder);
			}
		}
	}

	private void SpawnLevelComponents(){
        //Mapping 1D into 2D World Space in reverse order
        int x;
        int y;
        levelHolder = new GameObject("Level").transform;
        foreach (int index in JsonObject.Obstacles){
            x = index % JsonObject.BoardSize;
            y = (JsonObject.BoardSize - 1) - (index/JsonObject.BoardSize);
            instance = Instantiate(Obstacle, new Vector2(x, y), Quaternion.identity) as GameObject;
            instance.transform.SetParent(levelHolder);
        }

        x = JsonObject.BlueHole % JsonObject.BoardSize;
        y = (JsonObject.BoardSize - 1) - (JsonObject.BlueHole / JsonObject.BoardSize);
        instance = Instantiate(blueHole, new Vector2(x, y), Quaternion.identity) as GameObject;
        instance.transform.SetParent(levelHolder);

        x = JsonObject.RedHole % JsonObject.BoardSize;
        y = (JsonObject.BoardSize - 1) - (JsonObject.RedHole / JsonObject.BoardSize);
        instance = Instantiate(redHole, new Vector2(x, y), Quaternion.identity) as GameObject;
        instance.transform.SetParent(levelHolder);

        x = JsonObject.BlueBall % JsonObject.BoardSize;
        y = (JsonObject.BoardSize - 1) - (JsonObject.BlueBall / JsonObject.BoardSize);
        instance = Instantiate(blueBall, new Vector2(x, y), Quaternion.identity) as GameObject;
        instance.transform.SetParent(levelHolder);

        x = JsonObject.RedBall % JsonObject.BoardSize;
        y = (JsonObject.BoardSize - 1) - (JsonObject.RedBall / JsonObject.BoardSize);
        instance = Instantiate(redBall, new Vector2(x, y), Quaternion.identity) as GameObject;
        instance.transform.SetParent(levelHolder);
    }

    private void FiveByFiveCameraSettings()
    {
        Vector3 pos = new Vector3(2f, 2.57f, -10f);
        MainCamera.transform.position = pos;
        MainCamera.orthographicSize = 4.6f;
    }

    private void SixBySixCameraSettings(){
		Vector3 pos = new Vector3(2.5f,3.27f,-10f);
		MainCamera.transform.position = pos;
		MainCamera.orthographicSize = 5.5f; 
	}
}