using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Humanoid {

    [HideInInspector] public SoSharedHumanoidStats sharedEnemyStats;
    [HideInInspector] public SoSharedAttackTime sharedEnemyAttackTime;

    [Header("Blueprints")]
    [SerializeField] private List<SoBlueprintHumanoidStats> _blueprintEnemyStats;
    [SerializeField] private SoBlueprintHurtColors _blueprintHurtColors;
    [Header("Shared Data")]
    [SerializeField] private SoSharedSpawnPositions _sharedSpawnPositions;
    [SerializeField] private SoSharedHumanoidStats _sharedPlayerStats;
    [SerializeField] private SoSharedPlayerProgression _soSharedPlayerProgression;
    [SerializeField] private SoSharedGameState _soSharedGameState;

    private SoBlueprintHumanoidStats _currentBlueprint;
    private MeshRenderer[] rends;
    private bool isDead = false;
    private Vector3 spawnedPoint;
    void Awake() {
        sharedEnemyStats = ScriptableObject.CreateInstance<SoSharedHumanoidStats>();
        _currentBlueprint = _blueprintEnemyStats[UnityEngine.Random.Range(0, _blueprintEnemyStats.Count)];
        sharedEnemyStats.SetFromBlueprint(_currentBlueprint);
        sharedEnemyAttackTime = ScriptableObject.CreateInstance<SoSharedAttackTime>();

        StartCoroutine(TryAttackPlayer());


        rends = GetComponentsInChildren<MeshRenderer>();

        spawnedPoint = _sharedSpawnPositions.TakeRandomSlot();
        transform.position = spawnedPoint;
    }
    private void OnEnable() {
        CheckForChanges();
        sharedEnemyStats.OnDataUpdated += CheckForChanges;


    }
    private void OnDisable() {
        sharedEnemyStats.OnDataUpdated -= CheckForChanges;

    }
    private void CheckForChanges() {
        if (isDead || _soSharedGameState.GameState != SoSharedGameState.State.Play) {
            return;
        }
        CheckForDeath();
        SetMaterialColor();
    }
    private int GetRandomAttackTime() {
        return UnityEngine.Random.Range(3, 6);
    }
    private IEnumerator TryAttackPlayer() {

        int randomTime = GetRandomAttackTime();
        for(int i= randomTime; i> 0; i--) {
            sharedEnemyAttackTime.TimeUntilAttack = i;
            yield return new WaitForSeconds(1);
        }

        if (isDead == false && _soSharedGameState.GameState == SoSharedGameState.State.Play) {
            HitPlayer();
            StartCoroutine(TryAttackPlayer());
        }
    }

    protected override void SetMaterialColor() {

        float hpPercentage = (float)sharedEnemyStats.Hp / (float)_currentBlueprint.Hp;

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
        if (sharedEnemyStats.Hp == 0) {
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
        _sharedSpawnPositions.FreeSlot(spawnedPoint);
        _soSharedPlayerProgression.Exp += 50;
        Destroy(this.gameObject, 0.5f);
    }

    private void HitPlayer() {
        if(sharedEnemyStats.Damage - _sharedPlayerStats.Defense > 0) {
            _sharedPlayerStats.Hp -= (sharedEnemyStats.Damage - _sharedPlayerStats.Defense);
        }
        if (_sharedPlayerStats.Hp < 0) {
            _sharedPlayerStats.Hp = 0;
        }
    }

    public void TakePlayerDmg() {
        if(_sharedPlayerStats.Hp == 0) {
            return;
        }

        if (_sharedPlayerStats.Damage - sharedEnemyStats.Defense > 0) {
            sharedEnemyStats.Hp -= (_sharedPlayerStats.Damage - sharedEnemyStats.Defense);
        }
        if (sharedEnemyStats.Hp < 0) {
            sharedEnemyStats.Hp = 0;
        }
    }
     
}
