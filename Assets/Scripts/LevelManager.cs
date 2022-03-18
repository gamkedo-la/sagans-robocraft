using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int numberOfDroidParts;
    public int numberOfCorrectlyPositionedDroidParts;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCorrectlyPositionedDroidParts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfCorrectlyPositionedDroidParts == numberOfDroidParts)
        {
            //Debug.Log("WIN");
        }
    }

    public void DroidPartCorrectlyPositioned()
    {
        numberOfCorrectlyPositionedDroidParts++;
    }
}
