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
    XRDirectInteractor dirInteractor;
    XRRayInteractor rayInteractor;



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
        
        if(teleportMode){
            teleProvider.enabled = true;
            contMotion.enabled = false;
            snapTurn.enabled = true;
            contTurn.enabled = false;
            rayInteractor = rightHandControllerGameObject.AddComponent(typeof(XRRayInteractor)) as XRRayInteractor;

        } else {
            teleProvider.enabled = false;
            contMotion.enabled = true;
            snapTurn.enabled = false;
            contTurn.enabled = true;
            dirInteractor = rightHandControllerGameObject.AddComponent(typeof(XRDirectInteractor)) as XRDirectInteractor;
        }

    }

    private void pauseGameAction(InputAction.CallbackContext obj)
    {
        /*
        if(teleportMode){
            teleportMode = false;
        }
        else if (!teleportMode){
            teleportMode = true;
        }
        */

        toggleTeleportMode();

    }

    private void toggleTeleportMode(){
        if(teleportMode){
            teleProvider.enabled = true;
            contMotion.enabled = false;
            snapTurn.enabled = true;
            contTurn.enabled = false;
            if(dirInteractor){
	            Destroy(dirInteractor);
            }
            rayInteractor = rightHandControllerGameObject.AddComponent(typeof(XRRayInteractor)) as XRRayInteractor;
            Debug.Log(dirInteractor);
            Debug.Log(rayInteractor);

        } else {
            teleProvider.enabled = false;
            contMotion.enabled = true;
            snapTurn.enabled = false;
            contTurn.enabled = true;
            if(rayInteractor){
	            Destroy(rayInteractor);
            }
            XRDirectInteractor dirInteractor = rightHandControllerGameObject.AddComponent(typeof(XRDirectInteractor)) as XRDirectInteractor;
            Debug.Log(dirInteractor);
            Debug.Log(rayInteractor);
        }  
        teleportMode = !teleportMode;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(teleportMode){
            teleProvider.enabled = true;
            contMotion.enabled = false;
            snapTurn.enabled = true;
            contTurn.enabled = false;
            if(dirInteractor){
	            Destroy(dirInteractor);
            }
            rayInteractor = rightHandControllerGameObject.AddComponent(typeof(XRRayInteractor)) as XRRayInteractor;
            Debug.Log(dirInteractor);
            Debug.Log(rayInteractor);

        } else {
            teleProvider.enabled = false;
            contMotion.enabled = true;
            snapTurn.enabled = false;
            contTurn.enabled = true;
            if(rayInteractor){
	            Destroy(rayInteractor);
            }
            XRDirectInteractor dirInteractor = rightHandControllerGameObject.AddComponent(typeof(XRDirectInteractor)) as XRDirectInteractor;
            Debug.Log(dirInteractor);
            Debug.Log(rayInteractor);
        }   
        */
    }
}