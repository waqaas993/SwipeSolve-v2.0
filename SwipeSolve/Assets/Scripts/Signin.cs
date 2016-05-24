using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Signin : MonoBehaviour
{

    private static string URL;
    private static InputField Username;
    private static InputField Password;
    private static GameObject OnScreenButtonsPanel;

    void Awake()
    {
        OnScreenButtonsPanel = GameObject.Find("fill-all");
        Defaults();
    }

    public void Defaults()
    {
        OnScreenButtonsPanel.SetActive(false);
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
        else
            Debug.Log(Data.text);

    }
}
