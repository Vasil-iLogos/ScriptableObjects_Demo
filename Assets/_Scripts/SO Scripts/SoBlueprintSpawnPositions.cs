using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SoBlueprintSpawnPositions : ScriptableObject
{
    [SerializeField] private List<Vector3> _slots;
    public List<Vector3> Slots { get { return _slots; } }

}
