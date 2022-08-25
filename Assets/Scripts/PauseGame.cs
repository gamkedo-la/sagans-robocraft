using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public bool teleportMode = false;

    private Transform locomotionSystem;
    private Transform cameraOffset;
    private Transform rightHandController;
    private ContinuousMoveProviderBase contMotion;
    private SnapTurnProviderBase snapTurn;


    // Start is called before the first frame update
    void Start()
    {

        locomotionSystem = transform.Find("Locomotion System");
        contMotion = locomotionSystem.GetComponent<ContinuousMoveProviderBase>();
        snapTurn = locomotionSystem.GetComponent<SnapTurnProviderBase>();

        cameraOffset = transform.Find("Camera Offset");
        rightHandController = cameraOffset.Find("RightHand Controller");

        //rightHandController.AddComponent(typeof(XRDirectInteractor)) as XRDirectInteractor;
        //idk why the below *has* to be assigned to a variable
        //currently you need to either convert/find the gameObject attached to rightHandController
        XRDirectInteractor dirInteractor = gameObject.AddComponent(typeof(XRDirectInteractor)) as XRDirectInteractor;


        Debug.Log(cameraOffset);
        Debug.Log(rightHandController);
        
        if(teleportMode){
            contMotion.enabled = false;
            snapTurn.enabled = true;
        } else {
            contMotion.enabled = true;
            snapTurn.enabled = false;
        }
        //Debug.Log(contMotion.enabled);
        //Debug.Log(snapTurn.enabled);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
