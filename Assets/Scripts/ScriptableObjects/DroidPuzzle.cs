using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DroidPuzzle", order = 1)]
public class DroidPuzzle : ScriptableObject
{
    public bool isSolved = false;
    public GameObject referenceDroid;
    public GameObject targetDroid;
    public List<DroidPart> droidPartList;

    //init positions
    public Vector3 referenceDroidPosition;
    public Vector3 targetDroidPosition;
    public List<Vector3> droidPartPostions;

    //audio
    public AudioClip puzzleAudioClip;
}
