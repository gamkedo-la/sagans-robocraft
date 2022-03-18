using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int numberOfDroidParts;
    public int numberOfCorrectlyPositionedDroidParts;

    public List<DroidPart> allDroidPart;
 

    // Start is called before the first frame update
    void Start()
    {
        numberOfCorrectlyPositionedDroidParts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool allPartsLocked = true;
        foreach (var part in allDroidPart)
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

}
