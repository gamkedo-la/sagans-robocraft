using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public List<DroidPuzzle> droidPuzzles;
    public int currentDroidPuzzleIndex;
    public DroidPuzzle currentDroidPuzzle;

    private GameObject targetDroid;
    private GameObject referenceDroid;
    private List<DroidPart> allDroidParts = new List<DroidPart>();

    public InputActionReference changeDroidReference;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            changeDroidReference.action.performed += VRChangeDroid;
        }

        currentDroidPuzzleIndex = 0;
        currentDroidPuzzle = droidPuzzles[currentDroidPuzzleIndex];
        RenderDroidPuzzle();

    }

    // Update is called once per frame
    void Update()
    {
         CheckDroidPartsLocked(allDroidParts);
    }

    public void ChangeDroid()
    {
        // TODO: switch based on list of droid puzzles - dynamic support
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

    private void VRChangeDroid(InputAction.CallbackContext obj)
    {
        Debug.Log("VR mode?");
        ChangeDroid();
    }


    public void RenderDroidPuzzle()
    {
        GameObject referenceDroid = currentDroidPuzzle.referenceDroid;
        GameObject targetDroid = currentDroidPuzzle.targetDroid;
        List<DroidPart> droidParts = currentDroidPuzzle.droidPartList;

        this.targetDroid = Instantiate(targetDroid, currentDroidPuzzle.targetDroidPosition, Quaternion.identity);
        this.referenceDroid = Instantiate(referenceDroid, currentDroidPuzzle.referenceDroidPosition, Quaternion.identity);
        this.allDroidParts.Clear();

        int partCounter = 0;
        foreach (DroidPart part in droidParts)
        {
            this.allDroidParts.Add(Instantiate(part, currentDroidPuzzle.droidPartPostions[partCounter], Quaternion.identity));
            partCounter++;
        }
    }

}
