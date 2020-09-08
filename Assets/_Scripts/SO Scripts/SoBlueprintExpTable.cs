using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SoBlueprintExpTable : ScriptableObject
{
    [SerializeField] private List<int> _expTable;
    public List<int> ExpTable { get { return _expTable; }  }
}
