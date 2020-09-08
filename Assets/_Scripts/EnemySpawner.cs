using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [Header("Shared Data")]
    [SerializeField] private SoSharedGameState _soSharedGameState;
    [SerializeField] private SoSharedSpawnPositions spawnPositions;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {

        if (spawnPositions.HasFreeSlots()) {
            Instantiate(enemyPrefab);
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(Spawn());

    }
}
