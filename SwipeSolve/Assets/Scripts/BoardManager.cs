using UnityEngine;
using System;  //to use serializeable attribute
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour 
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
	public GameObject[] Obstacles;
	public GameObject[] floorTiles;
	public Camera MainCamera;

	//Deciding a Tile to place on Board
	private GameObject toInstantiate;
	//To keep hierarchy clean for board and level
	private Transform boardHolder;
	private Transform levelHolder;
	//To keep a static copy of generated tile instance so that we can child it to above parents
	private GameObject instance;

	void SetBoard(){
		int level = PlayerPrefs.GetInt("CurrentLevel");
		//If Its WorldOne
		if (level < 6){
			rows = 6;
			columns = 6;
		}
		//If Its WorldTwo
		else if (level > 5 && level < 12){
			rows = 7;
			columns = 7;
		}
		//If Its WorldThree
		else if (level > 11 && level < 18){
			rows = 8;
			columns = 8;
		}
		//If Its Final BOSS Level
		else if ( level == 18){
			rows = 9;
			columns = 9;
		}
	}

	void BoardSetup (){
		SetBoard();
		boardHolder = new GameObject("Board").transform;
		for (int x =-1; x <= columns; x++){
			for (int y =-1; y <= rows; y++){
				//Decide a tile for Floor tile from 4 given sprites based on the random function
				toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
				//If it's the border, instialize it with an invisible border
				if(x==-1 || x == columns || y==-1 || y == rows)
					toInstantiate = Wall;
				instance = Instantiate(toInstantiate, new Vector3(x,y,0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(boardHolder);
			}
		}
	}

	//Constructing Levels
	void LevelSetup(int level){
		levelHolder = new GameObject("Level").transform;
		switch (level) {
		case 1:
			SixBySixCameraSettings();
			//This is where we have to hardcode our levels
			//e.g Placing Obstacles, Balls, & Holes
			LevelOne();
			break;
		case 2:
			SixBySixCameraSettings();
			LevelTwo();
			break;
		case 3:
			SixBySixCameraSettings();
			LevelThree();
			break;
		case 4:
			SixBySixCameraSettings();
			LevelFour();
			break;
		case 5:
			SixBySixCameraSettings();
			LevelFive();
			break;
		case 6:
			SevenBySevenCameraSettings();
			LevelSix();
			break;		
		case 7:
			SevenBySevenCameraSettings();
			LevelSeven();
			break;		
		case 8:
			SevenBySevenCameraSettings();
			LevelEight();
			break;		
		case 9:
			SevenBySevenCameraSettings();
			LevelNine();
			break;		
		case 10:
			SevenBySevenCameraSettings();
			LevelTen();
			break;		
		case 11:
			SevenBySevenCameraSettings();
			LevelEleven();
			break;		
		case 12:
			EightByEightSettings();
			LevelTwelve();
			break;
		case 13:
			EightByEightSettings();
			Level13();
			break;
		case 14:
			EightByEightSettings();
			Level14();
			break;
		case 15:
			EightByEightSettings();
			Level15();
			break;
		case 16:
			EightByEightSettings();
			Level16();
			break;
		case 17:
			EightByEightSettings();
			Level17();
			break;
		case 18:
			NineByNineSettings();
			Level18();
			break;
		//And so on for 18 Levels
		}
	}

	public void SetupScene(int level){
		BoardSetup();
		LevelSetup (level);
	}

	private void LevelOne(){
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueHole, new Vector3(4,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(0,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(0,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}

	private void LevelTwo(){
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(4,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(2,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(4,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}

	private void LevelThree(){
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(0,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(3,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(0,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}

	private void LevelFour(){
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(4,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(1,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}

	private void LevelFive(){
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(5,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(2,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(3,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void LevelSix()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		
		instance = Instantiate(blueHole, new Vector3(0,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(5,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(3,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(3,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void LevelSeven()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(toInstantiate, new Vector3(4,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);



		instance = Instantiate(blueHole, new Vector3(5,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(6,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(0,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void LevelEight()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(6,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(0,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void LevelNine()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(4,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(2,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(1,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(5,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void LevelTen()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(2,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(6,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(1,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void LevelEleven()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(6,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(6,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(0,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(0,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void LevelTwelve()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(7,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(7,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(2,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(0,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void Level13()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		
		instance = Instantiate(blueHole, new Vector3(7,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(7,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(0,5,0f),	 Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(0,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}

	private void Level14()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);

		instance = Instantiate(blueHole, new Vector3(2,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(2,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(1,2,0f),	 Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(7,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);	
	}
	private void Level15()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		
		instance = Instantiate(blueHole, new Vector3(7,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(3,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(5,5,0f),	 Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void Level16()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		
		instance = Instantiate(blueHole, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(3,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(5,2,0f),	 Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(4,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void Level17()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		
		instance = Instantiate(blueHole, new Vector3(1,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(6,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(3,1,0f),	 Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(4,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}
	private void Level18()
	{
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(0,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(1,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(2,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(3,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,6,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(4,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(5,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,3,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(6,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,1,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(7,7,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(8,0,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(8,4,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		toInstantiate = Obstacles[Random.Range(0, Obstacles.Length)];
		instance = Instantiate(toInstantiate, new Vector3(8,5,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		
		instance = Instantiate(blueHole, new Vector3(8,8,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redHole, new Vector3(3,8,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(blueBall, new Vector3(1,5,0f),	 Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
		instance = Instantiate(redBall, new Vector3(0,2,0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent(levelHolder);
	}

	private void SixBySixCameraSettings(){
		Vector3 pos = new Vector3(2.5f,3.27f,-10f);
		MainCamera.transform.position = pos;
		MainCamera.orthographicSize = 5.5f; 
	}

	private void SevenBySevenCameraSettings(){
		Vector3 pos = new Vector3(3f,3.97f,-10f);
		MainCamera.transform.position = pos;
		MainCamera.orthographicSize = 6.5f;
	}

	private void EightByEightSettings(){
		Vector3 pos = new Vector3(3.5f,4.6f,-10f);
		MainCamera.transform.position = pos;
		MainCamera.orthographicSize = 7.4f;
	}

	private void NineByNineSettings(){
		Vector3 pos = new Vector3(4f,5.3f,-10f);
		MainCamera.transform.position = pos;
		MainCamera.orthographicSize = 8.4f;
	}
}