using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public bool teleportMode = false;

    private Transform locomotionSystem;
    private Transform cameraOffset;
    private Transform rightHandController;
    private GameObject rightHandControllerGameObject;
    private TeleportationProvider teleProvider;

    private ContinuousMoveProviderBase contMotion;
    private SnapTurnProviderBase snapTurn;
    private ContinuousTurnProviderBase contTurn;

    public InputActionReference pauseGameActionReference;


    // Start is called before the first frame update
    void Start()
    {
        pauseGameActionReference.action.performed += pauseGameAction;

        locomotionSystem = transform.Find("Locomotion System");
        
        teleProvider = locomotionSystem.GetComponent<TeleportationProvider>();
        contMotion = locomotionSystem.GetComponent<ContinuousMoveProviderBase>();
        snapTurn = locomotionSystem.GetComponent<SnapTurnProviderBase>();
        contTurn = locomotionSystem.GetComponent<ContinuousTurnProviderBase>();
        

        cameraOffset = transform.Find("Camera Offset");
        rightHandController = cameraOffset.Find("RightHand Controller");
        rightHandControllerGameObject = rightHandController.gameObject;

        Debug.Log(rightHandController);
        
        if(teleportMode){
            teleProvider.enabled = true;
            contMotion.enabled = false;
            snapTurn.enabled = true;
            contTurn.enabled = false;
            XRRayInteractor rayInteractor = rightHandControllerGameObject.AddComponent(typeof(XRRayInteractor)) as XRRayInteractor;

        } else {
            teleProvider.enabled = false;
            contMotion.enabled = true;
            snapTurn.enabled = false;
            contTurn.enabled = true;
            XRDirectInteractor dirInteractor = rightHandControllerGameObject.AddComponent(typeof(XRDirectInteractor)) as XRDirectInteractor;
        }

    }

    private void pauseGameAction(InputAction.CallbackContext obj)
    {
        Debug.Log("hello world");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
