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
    private GameObject rightHandControllerGameObject;
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
        rightHandControllerGameObject = rightHandController.gameObject;

        Debug.Log(cameraOffset);
        Debug.Log(rightHandController);
        
        if(teleportMode){
            contMotion.enabled = false;
            snapTurn.enabled = true;
            XRRayInteractor rayInteractor = rightHandControllerGameObject.AddComponent(typeof(XRRayInteractor)) as XRRayInteractor;

        } else {
            contMotion.enabled = true;
            snapTurn.enabled = false;
            XRDirectInteractor dirInteractor = rightHandControllerGameObject.AddComponent(typeof(XRDirectInteractor)) as XRDirectInteractor;
        }
        //Debug.Log(contMotion.enabled);
        //Debug.Log(snapTurn.enabled);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
