using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour {

	private int SavedLevel;
	private int CurrentWorld;

	public Sprite LevelLocked;

	[SerializeField]
	private Button[] btn_lvl;

	void Awake(){
		LoadPreferences();
		LoadLevels();
	}

	void LoadLevels(){
		CurrentWorld =  PlayerPrefs.GetInt("CurrentWorld");
		if (CurrentWorld == 1){
			for (int i = 5 ; i >= (SavedLevel+1) ; i--)
				if (i >= 0)
					DisableLevelButton(i);
		}
		else if (CurrentWorld == 2){
			for (int i = 5 ; i >= (SavedLevel-5) ; i--){
				if (i >= 0)
					DisableLevelButton(i);
			}
		}
		else if (CurrentWorld == 3){
			for (int i = 5 ; i >= (SavedLevel-11) ; i--){
				if (i >= 0)
					DisableLevelButton(i);
			}
		}
	}

	void LoadPreferences(){
		if(PlayerPrefs.HasKey("SavedLevel"))
			SavedLevel = PlayerPrefs.GetInt("SavedLevel");
		else 
			PlayerPrefs.SetInt("SavedLevel",0);
	}

	void DisableLevelButton(int i){
		btn_lvl[i].interactable = false;
		btn_lvl[i].image.sprite = LevelLocked;
	}


}
