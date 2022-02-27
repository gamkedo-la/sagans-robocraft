using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidPart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Droid Part Triggered");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player wants to play with me");
        }
    }
}
