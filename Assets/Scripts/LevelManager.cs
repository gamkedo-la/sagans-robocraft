using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LevelManager : MonoBehaviour
{
    public List<DroidPuzzle> droidPuzzles;
    private int currentDroidPuzzleIndex = -1;
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

        ChangeDroid();

    }

    // Update is called once per frame
    void Update()
    {
         CheckDroidPartsLocked(allDroidParts);
    }

    public void ChangeDroid()
    {
        currentDroidPuzzleIndex = currentDroidPuzzleIndex + 1;
        if (currentDroidPuzzleIndex < droidPuzzles.Count)
        {
            currentDroidPuzzle = droidPuzzles[currentDroidPuzzleIndex];
            RenderDroidPuzzle();
        }
        else
        {
            //No more droid puzzles
            Debug.Log("No more puzzles");
            if (DidPlayerWinGame())
            {
                Debug.Log("Player Won! Game Over");
                // TODO: Display Game Over Screen & Roll Credits
            }
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
            // animate droid and indicate to Player puzzle solved
            Debug.Log("droid locked!");
            currentDroidPuzzle.isSolved = true;
            ChangeDroid();
        }
    }

    private bool DidPlayerWinGame()
    {
        bool gameWon = true;
        foreach (var droid in droidPuzzles)
        {
            if (!droid.isSolved)
            {
                gameWon = false;
            }
        }

        return gameWon;
    }

    private void VRChangeDroid(InputAction.CallbackContext obj)
    {
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
            DroidPart instantiatedPart = Instantiate(part, currentDroidPuzzle.droidPartPostions[partCounter], Quaternion.identity);
            Transform hiddenPartInTarget = FindWithTag(this.targetDroid.transform.root, "DroidPart");
            instantiatedPart.correctDroidPart = hiddenPartInTarget.gameObject;
            this.allDroidParts.Add(instantiatedPart);
            partCounter++;
        }

    }

    // https://gamedev.stackexchange.com/questions/174398/how-find-child-using-tag
    Transform FindWithTag(Transform root, string tag)
    {
        foreach (Transform t in root.GetComponentsInChildren<Transform>())
        {
            if (t.CompareTag(tag)) return t;
        }
        return null;
    }

}
