using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class Signup : MonoBehaviour
{

    private static string URL;
    private static string uURL;

    private static InputField Username;
    private static InputField Password1;
    private static InputField Password2;
    private static InputField Email;
    private static InputField Nick;

    private static GameObject FillAll;
    private static GameObject userTaken;
    private static GameObject userAvailable;
    private static GameObject passMismatch;
	private static GameObject SignupSuccess;
	private static GameObject InternetIssue;


    void Awake()
    {
		FillAll = GameObject.Find("OnScreenButtonsPanel");
        userTaken = GameObject.Find("user-taken");
        userAvailable = GameObject.Find("user-available");
        passMismatch = GameObject.Find("pass-mismatch");
		SignupSuccess = GameObject.Find("Signup-Successful");
		InternetIssue = GameObject.Find("InternetConnectivity");

        Defaults();

        Username = GameObject.Find("InputField1").GetComponent<InputField>();
        Password1 = GameObject.Find("InputField2").GetComponent<InputField>();
        Password2 = GameObject.Find("InputField3").GetComponent<InputField>();
        Email = GameObject.Find("InputField4").GetComponent<InputField>();
        Nick = GameObject.Find("InputField5").GetComponent<InputField>();
    }

    public void Defaults()
    {
		FillAll.SetActive(false);
        userTaken.SetActive(false);
        userAvailable.SetActive(false);
        passMismatch.SetActive(false);
        SignupSuccess.SetActive(false);
		InternetIssue.SetActive(false);
    }

    // Use this for initialization
    public void OnSubmit()
    {
        Defaults();

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
				FillAll.SetActive(true);
			else
				StartCoroutine(signup());		

	}

    private IEnumerator signup()
    {
        WWW Data = new WWW(URL);
        yield return Data;
        //Server-sided Data validation
		if (HasConnection()) {
			if (Data.text == "1"){
				SignupSuccess.SetActive(true);
				yield return new WaitForSeconds(2);
				SceneManager.LoadScene("MainMenu");
			}
			else if (Data.text == "0"){
				userTaken.SetActive(true);
                userAvailable.SetActive(false);
			}
		} else {
			InternetIssue.SetActive(true);
		}

        //Continue to the new screen in else-clause
    }
		
	bool HasConnection()
	{
		try
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swipe.googglet.com/");
			request.Timeout = 5000;
			request.Credentials = CredentialCache.DefaultNetworkCredentials;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			if (response.StatusCode == HttpStatusCode.OK) return true;
			else return false;
		}
		catch
		{
			return false;
		}
	}

    public void UserAvailability() {
        uURL = "http://swipe.googglet.com/IsUserAvailable.php?username=";
        uURL += Username.text;
        StartCoroutine(CheckUserAvailability());
    }

    private IEnumerator CheckUserAvailability()
    {
        WWW Data = new WWW(uURL);
        yield return Data;
        if (Data.text == "1")
        {
            userTaken.SetActive(false);
            userAvailable.SetActive(true);
        }
        else if (Data.text == "0")
        {
            userTaken.SetActive(true);
            userAvailable.SetActive(false);
        }

    }
}
