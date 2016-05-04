using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Settings : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		int Music;
		if(PlayerPrefs.HasKey("Music"))
			Music = PlayerPrefs.GetInt("Music");
		else{
			PlayerPrefs.SetInt("Music",1);
			Music = 1;
		}
		int Sound;
		if(PlayerPrefs.HasKey("Sound"))
			Sound = PlayerPrefs.GetInt("Sound");
		else{
			PlayerPrefs.SetInt("Sound",1);
			Sound = 1;
		}

		Toggle ToggleSound = GameObject.Find("ToggleSound").GetComponent<Toggle>();
		Toggle ToggleMusic = GameObject.Find("ToggleMusic").GetComponent<Toggle>();


		if (Music == 0)
			ToggleMusic.isOn = false;
		else
			GameObject.Find("Background_Music").GetComponent<AudioSource>().Play();

		if (Sound == 0)
			ToggleSound.isOn = false;

	}
}
