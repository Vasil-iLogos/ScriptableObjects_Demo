using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoBlueprintHumanoidStats : ScriptableObject
{
    [SerializeField] private string _humanoidName;
    public string HumanoidName { get { return _humanoidName; } }

    [SerializeField] private int _hp;
    public int Hp { get { return _hp; } }


    [SerializeField] private int _damage;
    public int Damage { get { return _damage; } }


    [SerializeField] private int _defense;
    public int Defense { get { return _defense; } }


}
