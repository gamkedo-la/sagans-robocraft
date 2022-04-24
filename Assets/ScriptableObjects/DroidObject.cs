using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DroidObject", order = 1)]
public class DroidObject : ScriptableObject
{
    public GameObject referenceDroid;
    public GameObject targetDroid;
    public List<DroidPart> droidParts;
}
