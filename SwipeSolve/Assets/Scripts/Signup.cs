using UnityEngine;
using System.Collections;

public class Signup : MonoBehaviour
{

    string URL;
    string username;
    string password1;
    string password2;
    string email;
    string nick;


    // Use this for initialization
    IEnumerator Start()
    {
        username = "Hassaan";
        password1 = "hassaan";
        password2 = "hassaan";
        email = "hassaan@gmail.com";
        nick = "Physcho";

        URL = "http://swipe.googglet.com/signup.php?username=";
        URL += username + "&password1=";
        URL += password1 + "&password2=";
        URL += password2 + "&email=";
        URL += email + "&nick=";
        URL += nick;
        
        WWW Data = new WWW(URL);
        yield return Data;
        print(Data.text);
    }
}
