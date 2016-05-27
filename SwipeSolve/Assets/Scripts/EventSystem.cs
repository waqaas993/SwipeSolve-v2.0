using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour {
    private static GameObject BackgroundMusic;
    private static GameObject MainMusic;

    void Awake(){
		BackgroundMusic = GameObject.Find("Background_Music");
	}

	public void ChangeToScene (string sceneToChangeTo)
	{
		SceneManager.LoadScene(sceneToChangeTo);
	}

	public void ChangeToScene2 (string sceneToChangeTo)
	{
		Application.DontDestroyOnLoad(BackgroundMusic);
		SceneManager.LoadScene(sceneToChangeTo);
	}

	public void ChangeToScene3 (string sceneToChangeTo)
	{
        Destroy(BackgroundMusic);
        Destroy(MainMusic);
        SceneManager.LoadScene(sceneToChangeTo);
	}

    public void ChangeToScene4(string sceneToChangeTo)
    {
        Destroy(BackgroundMusic);
        int Music;
        Music = PlayerPrefs.GetInt("Music");
        if (Music == 1) {
            MainMusic = GameObject.Find("MainMusic");
            MainMusic.GetComponent<AudioSource>().Play();
            Application.DontDestroyOnLoad(MainMusic);
        }
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

	public void NextLevel(string World)
	{
		int CurrentLevel = PlayerPrefs.GetInt("CurrentLevel") + 1;
		PlayerPrefs.SetInt("CurrentLevel",CurrentLevel);
        if ((CurrentLevel-1) == 6 || (CurrentLevel-1) == 12)
            SceneManager.LoadScene("SelectWorld");
        else
            SceneManager.LoadScene(World);
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
        Destroy(MainMusic);
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
        Application.DontDestroyOnLoad(BackgroundMusic);
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