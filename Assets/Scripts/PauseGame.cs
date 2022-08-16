using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public bool teleportMode = false;

    private Transform locomotionSystem;

    // Start is called before the first frame update
    void Start()
    {
        locomotionSystem = transform.Find("Locomotion System");
        //Debug.Log(locomotionSystem.name);
        Debug.Log("welcome to the third Dean-mension!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
