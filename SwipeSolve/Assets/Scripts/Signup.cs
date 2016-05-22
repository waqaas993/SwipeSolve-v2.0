using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Signup : MonoBehaviour
{

    private static string URL;

    private static InputField Username;
    private static InputField Password1;
    private static InputField Password2;
    private static InputField Email;
    private static InputField Nick;


    // Use this for initialization
    public void OnSubmit()
    {
        Username = GameObject.Find("InputField1").GetComponent<InputField>();
        Password1 = GameObject.Find("InputField2").GetComponent<InputField>();
        Password2 = GameObject.Find("InputField3").GetComponent<InputField>();
        Email = GameObject.Find("InputField4").GetComponent<InputField>();
        Nick = GameObject.Find("InputField5").GetComponent<InputField>();

        URL = "http://swipe.googglet.com/signup.php?username=";
        URL += Username.text + "&password1=";
        URL += Password1.text + "&password2=";
        URL += Password2.text + "&email=";
        URL += Email.text + "&nick=";
        URL += Nick.text;

        StartCoroutine(signup());

    }

    private IEnumerator signup() {
        WWW Data = new WWW(URL);
        yield return Data;
        print(Data.text);
    }
}
