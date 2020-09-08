using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;


public class Player : Humanoid {

    [Header("Blueprints")]
    [SerializeField] private SoBlueprintHurtColors _blueprintHurtColors;
    [SerializeField] private SoBlueprintHumanoidStats _blueprintPlayerStats;
    [Header("Shared Data")]
    [SerializeField] private SoSharedHumanoidStats _sharedPlayerStats;
    [SerializeField] private SoSharedGameState _soSharedGameState;

    private MeshRenderer[] rends;
    private bool isDead = false;

    private void Awake() {
        _sharedPlayerStats.SetFromBlueprint(_blueprintPlayerStats);
        rends = GetComponentsInChildren<MeshRenderer>();

    }
    private void OnEnable() {
        CheckForChanges();
        _sharedPlayerStats.OnDataUpdated += CheckForChanges;
    }
    private void OnDisable() {
        _sharedPlayerStats.OnDataUpdated -= CheckForChanges;

    }
    private void OnDestroy() {
        _sharedPlayerStats.SetFromBlueprint(_blueprintPlayerStats);
    }
    private void CheckForChanges()
    {
        if (isDead || _soSharedGameState.GameState != SoSharedGameState.State.Play) {
            return;
        }
        CheckForDeath();
        SetMaterialColor();
    }

    protected override void SetMaterialColor() {

        float hpPercentage = (float)_sharedPlayerStats.Hp / (float)_blueprintPlayerStats.Hp;

        foreach (MeshRenderer rend in rends) {
            if (hpPercentage < 0.25f) {
                rend.material.color = _blueprintHurtColors.Dying;
            } else if (hpPercentage < 0.75f) {
                rend.material.color = _blueprintHurtColors.Hurt;
            } else {
                rend.material.color = _blueprintHurtColors.Normal;
            }
        }
    }
    protected override void CheckForDeath() {
        if (_sharedPlayerStats.Hp == 0) {
            isDead = true;
            Die();
        }
    }
    protected override void Die() {

        foreach (MeshRenderer rend in rends) {
            rend.material.color = _blueprintHurtColors.Dead;
        }
        transform.Rotate(new Vector3(0, 0, 90));
        transform.position -= Vector3.up / 2;
        _soSharedGameState.GameState = SoSharedGameState.State.GameOver;
    }

}
