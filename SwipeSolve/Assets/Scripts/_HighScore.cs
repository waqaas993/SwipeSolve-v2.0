using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _HighScore : MonoBehaviour {

	[SerializeField]
	private Text[] Text_HighScore;

	// Use this for initialization
	void Awake() {
		for( int i = 0 ; i < 18 ; i++ ){
			if(PlayerPrefs.HasKey((i+1).ToString()))
				Text_HighScore[i].text = "" + PlayerPrefs.GetInt((i+1).ToString()); 
			else
				Text_HighScore[i].text = "-";
		}	
	}
}