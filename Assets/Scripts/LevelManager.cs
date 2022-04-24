using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{

    public List<DroidPart> allDroidPart;
    
    public GameObject referenceDroidA;
    public GameObject targetDroidA;
    public List<DroidPart> allDroidAParts;

    public GameObject referenceDroidB;
    public GameObject targetDroidB;
    public List<DroidPart> allDroidBParts;

    public InputActionReference changeDroidReference = null;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            changeDroidReference.action.started += VRChangeDroid;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDestroy()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            changeDroidReference.action.started -= VRChangeDroid;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (referenceDroidA.activeSelf)
        {
            CheckDroidPartsLocked(allDroidAParts);
        }
        else
        {
            CheckDroidPartsLocked(allDroidBParts);
        }

    }

    public void ChangeDroid()
    {
        if (referenceDroidA.activeSelf)
        {
            SetDroidAActive(false);
            SetDroidBActive(true);
        } 
        else if (referenceDroidB.activeSelf)
        {
            SetDroidAActive(true);
            SetDroidBActive(false);
        }
    }

    private void SetDroidAActive(bool isActive)
    {
        referenceDroidA.SetActive(isActive);
        targetDroidA.SetActive(isActive);

        foreach (var part in allDroidAParts)
        {
            part.gameObject.SetActive(isActive);
        }
    }

    private void SetDroidBActive(bool isActive)
    {
        referenceDroidB.SetActive(isActive);
        targetDroidB.SetActive(isActive);

        foreach (var part in allDroidBParts)
        {
            part.gameObject.SetActive(isActive);
        }
    }

    private void CheckDroidPartsLocked(List<DroidPart> allDroidParts)
    {
        bool allPartsLocked = true;
        foreach (var part in allDroidParts)
        {
            if (part.isLocked == false)
            {
                allPartsLocked = false;
                break;
            }
        }

        if (allPartsLocked)
        {
            Debug.Log("droid locked!");

        }
    }

    private void VRChangeDroid(InputAction.CallbackContext context)
    {
        Debug.Log("VR mode?");
        ChangeDroid();
    }

}
