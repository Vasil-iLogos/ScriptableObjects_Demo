using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SoBlueprintHurtColors : ScriptableObject
{
    [SerializeField] private Color _normal;
    public Color Normal { get { return _normal; } }


    [SerializeField] private Color _hurt;
    public Color Hurt { get { return _hurt; } }


    [SerializeField] private Color _dying;
    public Color Dying { get { return _dying; } }

    [SerializeField] private Color _dead;
    public Color Dead { get { return _dead; } }

}
