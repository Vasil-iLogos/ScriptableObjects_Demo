using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedDataManager : MonoBehaviour
{
    [Header("Shared Data")]
    [SerializeField] private SoSharedSpawnPositions _sharedSpawnPositions;
    [SerializeField] private SoSharedHumanoidStats _sharedPlayerStats;
    [SerializeField] private SoSharedPlayerProgression _soSharedPlayerProgression;
    [SerializeField] private SoSharedGameState _soSharedGameState;
    
    void Awake()
    {
        _sharedSpawnPositions.Reset();
       // _sharedPlayerStats.SetFromBlueprint();
        _soSharedPlayerProgression.Reset();
        _soSharedGameState.GameState = SoSharedGameState.State.Play;
    }


}
