using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SoBlueprintPlayerBuffs : ScriptableObject
{
    [SerializeField] private List<int> _damageBuff;
    public List<int> DamageBuff { get { return _damageBuff; } }
    
    [SerializeField] private List<int> _defenseBuff;
    public List<int> DefenseBuff { get { return _defenseBuff; } }

}
