using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Junk", menuName = "Scriptable Objects/JunkSO")]
public class JunkSO : ScriptableObject
{
    public string junkName = "Junk";
    public int maxHP = 2;
    public List<DropRate> dropList;
}
