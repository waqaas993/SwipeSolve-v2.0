using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;

	//Scoring Pattern Data Members
	private static int swipes = 0; //Total no. of swipes
	private static double multiplier = 20; //Multiplier associated with each number of swipe
	private const int MAXWINDOW = 20; //Maximum Window
	private static Text GameText;
	private static int score;
	//Data Members for Time-attack Mode
	private static int CurrentSec;
	private static int sec;
	private static float timeCount;
	public static float startTime;
	//Pause Panel UI Elements
	private static GameObject PausePanel;
	private static Text txt_LevelNo;
	private static Text txt_Score;
	private static Text txt_BestScore;
	private static Text LevelNum;
	//HowTo Panel
	private static GameObject HowTo;
	//Survival Panel
	private static GameObject SurvivalInstr;
	//Flag for state of the Game
	public static bool isGameOver;
	//Current level being played
	private static int level;
	[SerializeField]
	private Button btn_Next;

	// Use this for initialization
	void Awake () 
	{
		sec = 15;
		startTime = Time.time;
		boardScript = GetComponent<BoardManager>();
		InitGame();
	}

	void InitGame()
	{
		isGameOver = false;
		swipes = 0;
		multiplier = 20;
		level = PlayerPrefs.GetInt("CurrentLevel");
		GameText = GameObject.Find("GameText").GetComponent<Text>();
		GameText.text = " Swipes: " + 0;
		LevelNum = GameObject.Find("txt_LevelNum").GetComponent<Text>();
		if ( level > 0 && level < 7 )
			LevelNum.text = "Level #" + level;
		else if ( level > 6 && level < 13 )
			LevelNum.text = "Level #" + (level - 6);
		else if ( level > 12 && level < 19 )
			LevelNum.text = "Level #" + (level - 12);
		HowTo = GameObject.Find("HowTo");
		if (level == 1){
			isGameOver = true;
			HowTo.SetActive(true);
		}
		else
			HowTo.SetActive(false);
		SurvivalInstr = GameObject.Find("SurvivalInstr");
		if (level == 6 || level == 12 || level == 18){
			GameText.text = "Time Left: 15";
			GameText.fontSize = 120;
			isGameOver = true;
			SurvivalInstr.SetActive(true);
		}
		else
			SurvivalInstr.SetActive(false);
		PausePanel = GameObject.Find("PausePanel");
		txt_BestScore = GameObject.Find("txt_BestScore").GetComponent<Text>();
		txt_LevelNo = GameObject.Find("txt_LevelNo").GetComponent<Text>();
		txt_Score = GameObject.Find("txt_Score").GetComponent<Text>();
		PausePanel.SetActive(false);
        if (level == 18)
            btn_Next.interactable = false;
        boardScript.SetupScene(level);
	}
	
	public static void GameOver() {
		//Calculate score If Arcade level
		if ( level != 6 && level != 12 && level != 18){
			score = (int)calScore();
		}
		//Calculate Score If BOSS level
		else{
			score = (int) calBossScore();
		}
		//Updating Player Preferences on Update
		int SavedLevel = PlayerPrefs.GetInt("SavedLevel");
		if (level > SavedLevel && score > 0)
			PlayerPrefs.SetInt("SavedLevel",level);
		if (score > 0 && (PlayerPrefs.GetInt("Sound") == 1))
				GameObject.Find("Level_Completion_Sound").GetComponent<AudioSource>().Play();
		//Display it on the Pause Panel Canvas
		if ( level > 0 && level < 7 )
			txt_LevelNo.text = "Level #" + level;
		else if ( level > 6 && level < 13 )
			txt_LevelNo.text = "Level #" + (level - 6);
		else if ( level > 12 && level < 19 )
			txt_LevelNo.text = "Level #" + (level - 12);
		txt_Score.text = "SCORE: " + score;
		//If the Player played this level before, retrieve his Best Score
		if(PlayerPrefs.HasKey(level.ToString())){
			if (score > PlayerPrefs.GetInt(level.ToString()))
				PlayerPrefs.SetInt(level.ToString(), score);
		}
		//Else store this first-time score as his Best Score
		else
			PlayerPrefs.SetInt(level.ToString(), score);
		if (level == 6 || level == 12 || level == 18)
			WorldUnlock();
		txt_BestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt(level.ToString());
		PausePanel.SetActive(true);
		isGameOver = true;
	}

	//Formula for determining the Final Score for Arcade levels
	private static double calScore(){
		if (swipes < 20)
			return  System.Math.Round(((MAXWINDOW+1)-swipes)*multiplier);
		else return 20;
	}

	//Formula for determining the Final Score for Time-attack levels
	private static double calBossScore(){
		return System.Math.Round(multiplier * CurrentSec);
	}

	private static void WorldUnlock(){
		if ( level == 6 & score!= 0)
			PlayerPrefs.SetInt("WorldTwo",1);
		if ( level == 12 & score!= 0)
			PlayerPrefs.SetInt("WorldThree",1);
	}

	//Update Swipes for Arcade Mode
	public static void UpdateSwipes(){
		if (Controller.PredBlueLoc != Controller.BlueBall.transform.position || Controller.PredRedLoc != Controller.RedBall.transform.position ){
			if (PlayerPrefs.GetInt("Sound") == 1)
				GameObject.Find("Swipe_Sound").GetComponent<AudioSource>().Play();
			Controller.PredBlueLoc = Controller.BlueBall.transform.position;
			Controller.PredRedLoc = Controller.RedBall.transform.position;
			//If Arcade level
			if ( level != 6 && level != 12 && level != 18){
			swipes++;
			if (swipes < 20)
				multiplier -= 0.25;
			}
		}
		if ( level != 6 && level != 12 && level != 18)
			GameText.text = "Swipes: " + swipes;
	}

	//Update Time for Time-attack Mode
	void Update(){
		if(!isGameOver){
			if ( level == 6 || level == 12 || level == 18){
				timeCount = Time.time - startTime;
				CurrentSec = (int) (timeCount % 60f);
				CurrentSec = 15 - CurrentSec;
				if(sec > CurrentSec){
					multiplier-=0.05;
					sec = CurrentSec;
				}
				GameText.text = "Time Left: " + CurrentSec.ToString();
				if (CurrentSec <= 0){
					isGameOver = true;
					GameOver();
				}
			}
		}
	}
}
