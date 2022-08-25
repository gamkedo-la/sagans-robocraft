using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gluePlayerCharacterToGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("starting y pos of the Player Rig is... " + transform);   
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;      
        */
        Vector3 glueToGround = transform.up;
        glueToGround.y = 0.0f;
        Debug.Log(transform.up);
    }
}
