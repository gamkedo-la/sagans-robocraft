using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVRorNot : MonoBehaviour
{
    public GameObject XRRig;
    public GameObject WebGLRig;
    private bool isOnXRDevice = false;
 
    private void Awake() 
    {
        if (Application.platform == RuntimePlatform.Android) 
        {
            isOnXRDevice = true;
        }

        if (Application.platform == RuntimePlatform.WebGLPlayer) 
        {
            isOnXRDevice = false;
        }

        XRRig.SetActive(isOnXRDevice);
        WebGLRig.SetActive(!isOnXRDevice);
    }
}
