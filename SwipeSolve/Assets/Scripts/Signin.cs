using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class Signin : MonoBehaviour
{

    private static string URL;
    private static GameObject FillAll;
    private static InputField Username;
    private static InputField Password;
    private static GameObject OnScreenButtonsPanel;
    private static GameObject loginSuccess;

    private static GameObject InternetIssue;

    void Awake()
    {
        FillAll = GameObject.Find("FillAll");
        OnScreenButtonsPanel = GameObject.Find("invalid-cred");
        loginSuccess = GameObject.Find("login-success");
        InternetIssue = GameObject.Find("InternetConnectivity");
        Defaults();
    }

    public void Defaults()
    {
        FillAll.SetActive(false);
        OnScreenButtonsPanel.SetActive(false);
        loginSuccess.SetActive(false);
        InternetIssue.SetActive(false);
    }

    // Use this for initialization
    public void OnSubmit()
    {
        Defaults();
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

        if (HasConnection())
        {
            if (Username.text == "" || Password.text == "")
                FillAll.SetActive(true);
            else if (Data.text == "0")
                OnScreenButtonsPanel.SetActive(true);
            else if (Data.text == "1")
            {
                loginSuccess.SetActive(true);
                yield return new WaitForSeconds(2);
                GameObject BackgroundMusic = GameObject.Find("Background_Music");
                Application.DontDestroyOnLoad(BackgroundMusic);
                SceneManager.LoadScene("MainMenu");
            }
        }
        else
            InternetIssue.SetActive(true);
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
}
