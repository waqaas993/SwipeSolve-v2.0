using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Signin : MonoBehaviour
{

    private static string URL;
    private static InputField Username;
    private static InputField Password;
    private static GameObject OnScreenButtonsPanel;
    private static GameObject loginSuccess;

    void Awake()
    {
        OnScreenButtonsPanel = GameObject.Find("invalid-cred");
        loginSuccess = GameObject.Find("login-success");
        Defaults();
    }

    public void Defaults()
    {
        OnScreenButtonsPanel.SetActive(false);
        loginSuccess.SetActive(false);
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

        if (Data.text == "0")
            OnScreenButtonsPanel.SetActive(true);
        else if (Data.text == "1") {
            loginSuccess.SetActive(true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
