using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo)
	{
		Application.LoadLevel(sceneToChangeTo);
	}

	public void SelectLevel(int Level)
	{
		PlayerPrefs.SetInt("CurrentLevel",Level);
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
}