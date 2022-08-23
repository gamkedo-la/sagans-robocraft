using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public bool teleportMode = false;

    private Transform locomotionSystem;
    private ContinuousMoveProviderBase contMotion;
    private SnapTurnProviderBase snapTurn;


    // Start is called before the first frame update
    void Start()
    {

        locomotionSystem = transform.Find("Locomotion System");
        contMotion = locomotionSystem.GetComponent<ContinuousMoveProviderBase>();
        snapTurn = locomotionSystem.GetComponent<SnapTurnProviderBase>();
        
        if(teleportMode){
            contMotion.enabled = false;
            snapTurn.enabled = true;
        } else {
            contMotion.enabled = true;
            snapTurn.enabled = false;
        }
        //Debug.Log(contMotion.enabled);
        Debug.Log(snapTurn.enabled);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
