using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Signup : MonoBehaviour
{

    private static string URL;

    private static InputField Username;
    private static InputField Password1;
    private static InputField Password2;
    private static InputField Email;
    private static InputField Nick;

    private static GameObject OnScreenButtonsPanel;
    private static GameObject userTaken;
    private static GameObject passMismatch;
    private static GameObject SignupSuccess;


    void Awake()
    {
        OnScreenButtonsPanel = GameObject.Find("OnScreenButtonsPanel");
        userTaken = GameObject.Find("user-taken");
        passMismatch = GameObject.Find("pass-mismatch");
        SignupSuccess = GameObject.Find("Signup-Succesful");
        Defaults();
    }

    public void Defaults()
    {
        OnScreenButtonsPanel.SetActive(false);
        userTaken.SetActive(false);
        passMismatch.SetActive(false);
        SignupSuccess.SetActive(false);
    }

    // Use this for initialization
    public void OnSubmit()
    {
        Defaults();
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



        //Client-sided Data validation
        if (Password1.text != Password2.text)
            passMismatch.SetActive(true);
        else if (Username.text == "" || Password1.text == "" || Email.text == "" || Nick.text == "")
            OnScreenButtonsPanel.SetActive(true);
        else
            StartCoroutine(signup());
    }

    private IEnumerator signup()
    {
        WWW Data = new WWW(URL);
        yield return Data;
        //Server-sided Data validation
        if (Data.text == "0")
            userTaken.SetActive(true);
        else if (Data.text == "1"){
            SignupSuccess.SetActive(true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("MainMenu");
        }
        //Continue to the new screen in else-clause
    }

}
