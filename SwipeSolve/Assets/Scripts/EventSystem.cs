using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo)
	{
		SceneManager.LoadScene(sceneToChangeTo);
	}

	public void SelectLevel(int Level)
	{
		PlayerPrefs.SetInt("CurrentLevel",Level);
	}

    public void SelectLevelEditor(int BoardSize)
    {
        PlayerPrefs.SetInt("CurrentLevelEditor", BoardSize);
    }

    public void SelectWorld(int World)
	{
		PlayerPrefs.SetInt("CurrentWorld",World);
	}

	public void NextLevel()
	{
		int CurrentLevel = PlayerPrefs.GetInt("CurrentLevel") + 1;
		PlayerPrefs.SetInt("CurrentLevel",CurrentLevel);
	}

	public void PlayButtonSound(){
		int Sound;
		if(PlayerPrefs.HasKey("Sound"))
			Sound = PlayerPrefs.GetInt("Sound");
		else{
			PlayerPrefs.SetInt("Sound",1);
			Sound = 1;
		}
		
		if (Sound == 1)
			GameObject.Find("Button_Sound").GetComponent<AudioSource>().Play();	
	}

	public void QuitSwipeSolve(){
		Application.Quit();
	}

	public void ToggleMusic(){
		Toggle ToggleMusic = GameObject.Find("ToggleMusic").GetComponent<Toggle>();
		bool Music = ToggleMusic.isOn;
		if (!Music){
			GameObject.Find("Background_Music").GetComponent<AudioSource>().mute = true;
			PlayerPrefs.SetInt("Music",0);
		}
		else if (Music){
			GameObject.Find("Background_Music").GetComponent<AudioSource>().mute = false;
			GameObject.Find("Background_Music").GetComponent<AudioSource>().Play();
			PlayerPrefs.SetInt("Music",1);
		}
	}

	public void ToggleSound(){
		Toggle ToggleSound = GameObject.Find("ToggleSound").GetComponent<Toggle>();
		bool Sound = ToggleSound.isOn;
		if (!Sound)
			PlayerPrefs.SetInt("Sound",0);
		else if (Sound)
			PlayerPrefs.SetInt("Sound",1);
	}

	public void DisableHowTo(){
		GameObject HowTo;
		HowTo = GameObject.Find("HowTo");
		GameManager.isGameOver = false;
		HowTo.SetActive(false);
	}

	public void DisableSurvivalInstr(){
		GameObject SurvivalInstr;
		SurvivalInstr = GameObject.Find("SurvivalInstr");
		GameManager.isGameOver = false;
		GameManager.startTime = Time.time;
		SurvivalInstr.SetActive(false);
	}
    /*
	void update(){
	  if (Application.platform == RuntimePlatform.Android){ 
		if(Application.loadedLevelName=="MainMenu"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.Quit(); 
		} else 
		if(Application.loadedLevelName=="TapToStart"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.Quit(); 
		} else 
		if(Application.loadedLevelName=="SelectWorld"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("MainMenu"); 
		} else 
		if(Application.loadedLevelName=="Settings"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("MainMenu"); 
		} else 
		if(Application.loadedLevelName=="HighScores"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("MainMenu"); 
		} else 
		if(Application.loadedLevelName=="CustomLevels"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("MainMenu");
		} else 
		if(Application.loadedLevelName=="CustomSelectBoard"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("CustomLevels");
		} else 
		if(Application.loadedLevelName=="CustomCreateLevel5x5"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("CustomSelectBoard");
		} else 
		if(Application.loadedLevelName=="CustomCreateLevel6x6"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("CustomSelectBoard");
		} else 
		if(Application.loadedLevelName=="WorldOne"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("WorldOneSelectLevel");
		} else 
		if(Application.loadedLevelName=="WorldTwo"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("WorldTwoSelectLevel");
		} else 
		if(Application.loadedLevelName=="WorldThree"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("WorldThreeSelectLevel");
		} else 
		if(Application.loadedLevelName=="WorldOneSelectLevel"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("SelectWorld");
		} else 
		if(Application.loadedLevelName=="WorldTwoSelectLevel"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("SelectWorld");
		} else 
		if(Application.loadedLevelName=="WorldThreeSelectLevel"){
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("SelectWorld");
		}
	  }
	}
    */
}