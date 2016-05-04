using UnityEngine;
using System.Collections;

public class Preferences : MonoBehaviour {
	// Use this for initialization
	void Awake() {
		int Music;
		if(PlayerPrefs.HasKey("Music"))
			Music = PlayerPrefs.GetInt("Music");
		else{
			PlayerPrefs.SetInt("Music",1);
			Music = 1;
		}

		if (Music == 1)
			GameObject.Find("Background_Music").GetComponent<AudioSource>().Play();
	}
}
