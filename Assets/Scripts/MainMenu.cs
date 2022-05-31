using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string button1SceneName = "SampleScene";
    public string button2SceneName = "level2";
    

    public void onClickButton1()
    {
        SceneManager.LoadScene(this.button1SceneName);
    }
    public void onClickButton2()
    {
        SceneManager.LoadScene(this.button2SceneName);
    }
    

}
