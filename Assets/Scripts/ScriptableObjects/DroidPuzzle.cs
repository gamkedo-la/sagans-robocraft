using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DroidPuzzle", order = 1)]
public class DroidPuzzle : ScriptableObject
{
    public bool isSolved;
    public GameObject referenceDroid;
    public GameObject targetDroid;
    public List<DroidPart> droidPartList;
}
