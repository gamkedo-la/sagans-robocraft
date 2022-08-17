using System;
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

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            changeDroidReference.action.performed += VRChangeDroid;
        }

        audioManager = GetComponent<AudioManager>();
        ResetDroidPuzzlesSolved();
        ChangeDroid();

    }

    // Update is called once per frame
    void Update()
    {
         CheckDroidPartsLocked(allDroidParts);
    }

    public void ResetDroidPuzzlesSolved()
    {
        foreach (DroidPuzzle puzzle in droidPuzzles)
        {
            puzzle.isSolved = false;
        }
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

        this.targetDroid = Instantiate(targetDroid, currentDroidPuzzle.targetDroidPosition, targetDroid.transform.rotation);
        //disable rendering of reference droid - this could be used for an "easy mode"
        //this.referenceDroid = Instantiate(referenceDroid, currentDroidPuzzle.referenceDroidPosition, referenceDroid.transform.rotation);
        this.allDroidParts.Clear();
        List<Transform> hiddenPartsInTarget = FindChildrenWithTags(this.targetDroid.transform.root, "DroidPart");
        Dictionary<string, DroidPart> instantiatedParts = new Dictionary<string, DroidPart>();

        int partCounter = 0;
        foreach (DroidPart part in droidParts)
        {
            DroidPart instantiatedPart = Instantiate(part, currentDroidPuzzle.droidPartPostions[partCounter], part.transform.rotation);
            foreach (Transform hiddenPart in hiddenPartsInTarget)
            {
                if (CheckDroidPartReference(instantiatedPart, hiddenPart.gameObject))
                {
                    instantiatedPart.correctDroidPart = hiddenPart.gameObject;
                }
            }
            this.allDroidParts.Add(instantiatedPart);
            instantiatedParts.Add(instantiatedPart.droidPartReferenceId, instantiatedPart);
            partCounter++;
        }

        foreach (DroidPart part in this.allDroidParts)
        {
            if (part.prerequisiteDroidPartId != null && !String.Equals(part.prerequisiteDroidPartId, ""))
            {
                part.prequisiteDroidPart = instantiatedParts[part.prerequisiteDroidPartId].gameObject;
            }
        }

        if (currentDroidPuzzle.puzzleAudioClip != null)
        {
            PlayPuzzleAudio(currentDroidPuzzle.puzzleAudioClip);
        }
        else
        {
            StopPuzzleAudio();
        }
    }

    void PlayPuzzleAudio(AudioClip clip)
    {
        audioManager.PlayAudio(clip, true);
    }

    void StopPuzzleAudio()
    {
        audioManager.StopAudio();
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

    // Find multiple children with tags
    List<Transform> FindChildrenWithTags(Transform root, string tag)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform t in root.GetComponentsInChildren<Transform>())
        {
            if (t.CompareTag(tag))
            {
                children.Add(t);
            }
        }
        return children;
    }

    bool CheckDroidPartReference(DroidPart instantiatedDroidPart, GameObject hiddenPart)
    {
        DroidPart hiddenDroidPart = hiddenPart.GetComponent<DroidPart>();
        if (hiddenDroidPart != null)
        {
            return String.Equals(instantiatedDroidPart.droidPartReferenceId, hiddenDroidPart.droidPartReferenceId);
        }

        return false;
    }
}
