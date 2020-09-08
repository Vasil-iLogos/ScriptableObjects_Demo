using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffer : MonoBehaviour {

    [Header("Blueprints")]
    [SerializeField] private SoBlueprintPlayerBuffs _soBlueprintPlayerBuffs;
    [Header("Shared Data")]
    [SerializeField] private SoSharedHumanoidStats _sharedPlayerStats;
    [SerializeField] private SoSharedPlayerProgression _soSharedPlayerProgression;

    private int level = 0;
    private void OnEnable() {
        _soSharedPlayerProgression.OnDataUpdated += CheckForChanges;
    }
    private void OnDisable() {
        _soSharedPlayerProgression.OnDataUpdated -= CheckForChanges;

    }

    private void CheckForChanges() {

        if (level < _soSharedPlayerProgression.Level) {
            level++;
            _sharedPlayerStats.Damage += _soBlueprintPlayerBuffs.DamageBuff[level];
            _sharedPlayerStats.Defense += _soBlueprintPlayerBuffs.DefenseBuff[level];
        }
    }

}

