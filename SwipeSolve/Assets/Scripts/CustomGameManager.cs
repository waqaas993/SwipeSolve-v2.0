using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomGameManager : MonoBehaviour {

	private CustomLoadLevel CustomLoadLevelScript;

	//Scoring Pattern Data Members
	private static int swipes = 0; //Total no. of swipes
	private static double multiplier = 20; //Multiplier associated with each number of swipe
	private const int MAXWINDOW = 20; //Maximum Window
	private static Text GameText;
	private static int score;
	//Pause Panel UI Elements
	private static GameObject PausePanel;
	private static Text txt_LevelNo;
	private static Text txt_Score;
	private static Text LevelNum;
	//Flag for state of the Game
	public static bool isGameOver;
	[SerializeField]
	private Button btn_Next;

	// Use this for initialization
	void Awake () 
	{
        CustomLoadLevelScript = GetComponent<CustomLoadLevel>();
		InitGame();
	}

	void InitGame()
	{
		isGameOver = false;
		swipes = 0;
		multiplier = 20;
		GameText = GameObject.Find("GameText").GetComponent<Text>();
		GameText.text = " Swipes: " + 0;
		LevelNum = GameObject.Find("txt_LevelNum").GetComponent<Text>();
        LevelNum.text = "Custom Level";
		LevelNum.fontSize = 90;
		PausePanel = GameObject.Find("PausePanel");
		txt_LevelNo = GameObject.Find("txt_LevelNo").GetComponent<Text>();
		txt_Score = GameObject.Find("txt_Score").GetComponent<Text>();
		PausePanel.SetActive(false);
        CustomLoadLevelScript.SetupScene();
	}
	
	public static void GameOver() {
        //Calculate score
        score = (int)calScore();
        //Updating Player Preferences on Update
        if (score > 0 && (PlayerPrefs.GetInt("Sound") == 1))
            GameObject.Find("Level_Completion_Sound").GetComponent<AudioSource>().Play();
        //Display it on the Pause Panel Canvas
        txt_LevelNo.text = "Custom Level";
		txt_Score.text = "SCORE: " + score;
		PausePanel.SetActive(true);
		isGameOver = true;
	}

	//Formula for determining the Final Score for Arcade levels
	private static double calScore(){
		if (swipes < 20)
			return  System.Math.Round(((MAXWINDOW+1)-swipes)*multiplier);
		else return 20;
	}

	//Update Swipes for Arcade Mode
	public static void UpdateSwipes(){
		if (Controller.PredBlueLoc != Controller.BlueBall.transform.position || Controller.PredRedLoc != Controller.RedBall.transform.position ){
			if (PlayerPrefs.GetInt("Sound") == 1)
				GameObject.Find("Swipe_Sound").GetComponent<AudioSource>().Play();
			Controller.PredBlueLoc = Controller.BlueBall.transform.position;
			Controller.PredRedLoc = Controller.RedBall.transform.position;
            //If Arcade level
            swipes++;
			if (swipes < 20)
				multiplier -= 0.25;
		}
        GameText.text = "Swipes: " + swipes;
	}
}
