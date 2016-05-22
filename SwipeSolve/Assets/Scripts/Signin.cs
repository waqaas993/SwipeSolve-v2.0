using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Signin: MonoBehaviour {

    private static string URL;
    private static InputField Username;
    private static InputField Password;


    // Use this for initialization
    public void OnSubmit()
    {
        Username = GameObject.Find("InputField1").GetComponent<InputField>();
        Password = GameObject.Find("InputField2").GetComponent<InputField>();

        URL = "http://swipe.googglet.com/login.php?username=";

        URL += Username.text + "&password=";
        URL += Password.text;

        StartCoroutine(login());
    }

    private IEnumerator login()
    {
        WWW Data = new WWW(URL);
        yield return Data;
        print(Data.text);
    }
}
