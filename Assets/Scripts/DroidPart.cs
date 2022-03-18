using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidPart : MonoBehaviour
{
    public GameObject correctDroidPart;
    private float LOCK_DISTANCE = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void checkPosition()
    {
        float deltaDroidParts = Vector3.Distance(correctDroidPart.transform.position, transform.position);
        Debug.Log(deltaDroidParts);
        if (deltaDroidParts < LOCK_DISTANCE)
        {
            transform.position = correctDroidPart.transform.position;
            transform.rotation = correctDroidPart.transform.rotation;

            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }
}
