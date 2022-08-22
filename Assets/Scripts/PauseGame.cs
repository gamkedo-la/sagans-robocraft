using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public bool teleportMode = false;

    private Transform locomotionSystem;
    //private ActionBasedContinuousMoveProvider contMotion;
    private ContinuousMoveProviderBase contMotion;

    // Start is called before the first frame update
    void Start()
    {
        locomotionSystem = transform.Find("Locomotion System");
        contMotion = locomotionSystem.GetComponent<ContinuousMoveProviderBase>();
        
        if(teleportMode){
            contMotion.enabled = false;
        }
        Debug.Log(contMotion.enabled);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
