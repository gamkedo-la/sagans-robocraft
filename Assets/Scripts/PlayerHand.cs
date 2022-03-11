using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public GameObject touchedObject = null;
    public bool isGrabbing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbing)
        {
            touchedObject.transform.position = transform.position;
            touchedObject.transform.rotation = transform.rotation;
        }
    }

    public void Grab()
    {
        if (isGrabbing)
        {
            LetGo();
            return;
        }

        if (touchedObject)
        {
            if (touchedObject.tag == "DroidPart")
            {
                isGrabbing = true;
            }
        }
    }

    public void LetGo()
    {
        isGrabbing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGrabbing)
        {
            return;
        }

        touchedObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (isGrabbing)
        {
            return;
        }
        touchedObject = null;
    }
}
