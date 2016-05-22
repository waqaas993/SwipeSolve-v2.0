using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

    string URL;
    string username;
    string password;


    // Use this for initialization
    IEnumerator Start(){
        username = "Haris";
        password = "haris";

        URL = "http://swipe.googglet.com/login.php?username=";

        URL += username + "&password=";
        URL += password;

        WWW Data = new WWW(URL);
        yield return Data;
        print(Data.text);
    }
}
