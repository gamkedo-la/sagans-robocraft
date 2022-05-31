using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string button1SceneName = "SampleScene";
    public string button2SceneName = "Options";
    public string button3SceneName = "Credits";


    public void onClickButton1()
    {
        SceneManager.LoadScene(this.button1SceneName);
    }
    public void onClickButton2()
    {
        SceneManager.LoadScene(this.button2SceneName);
    }
    public void onClickButton3()
    {
        SceneManager.LoadScene(this.button3SceneName);
    }


}
