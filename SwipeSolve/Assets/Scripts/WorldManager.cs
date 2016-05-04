using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour {

	private int WorldTwo;
	private int WorldThree;

	[SerializeField]
	private Button btn_World2;
	[SerializeField]
	private Button btn_World3;


	void Awake(){
		WorldTwo = 0;
		WorldThree = 0;
		LoadWorlds();
	}

	void LoadWorlds(){
		LoadPreferences();

		if (WorldTwo == 0) DisableWorldTwo();
		if (WorldThree == 0) DisableWorldThree();
	}

	void LoadPreferences(){
		if(PlayerPrefs.HasKey("WorldTwo") && PlayerPrefs.HasKey("WorldThree")){
			WorldTwo = PlayerPrefs.GetInt("WorldTwo");
			WorldThree = PlayerPrefs.GetInt("WorldThree");
		}
		else{
			PlayerPrefs.SetInt("WorldTwo",0);
			PlayerPrefs.SetInt("WorldThree",0);
		}
	}

	void DisableWorldTwo(){
		btn_World2.interactable = false;
	}
	
	void DisableWorldThree(){
		btn_World3.interactable = false;
	}
}
