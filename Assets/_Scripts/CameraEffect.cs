using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour {

    [Header("Shared Data")]
    [SerializeField] private SoSharedHumanoidStats _soSharedPlayerStats;

    private int lastPlayerHp;

    private void OnEnable() {
        lastPlayerHp = _soSharedPlayerStats.Hp;
        _soSharedPlayerStats.OnDataUpdated += CheckForPlayerDamage;
    }
    private void OnDisable() {
        _soSharedPlayerStats.OnDataUpdated -= CheckForPlayerDamage;
    }

    private void CheckForPlayerDamage() {
        if (lastPlayerHp != _soSharedPlayerStats.Hp) {

            lastPlayerHp = _soSharedPlayerStats.Hp;
            StartCoroutine(CameraEffectSequence());
        }
    }
    IEnumerator CameraEffectSequence() {
        yield return new WaitForSeconds(0.025f);
        transform.position += Vector3.right / 10;
        transform.Rotate(new Vector3(0, 0, 1));
        yield return new WaitForSeconds(0.025f);
        transform.position -= Vector3.right / 20;
        transform.Rotate(new Vector3( 0, 0, -2));

        yield return new WaitForSeconds(0.025f);
        transform.position += Vector3.right / 20;
        transform.Rotate(new Vector3(0, 0, 2));
        yield return new WaitForSeconds(0.025f);
        transform.position -= Vector3.right / 10;
        transform.Rotate(new Vector3( 0, 0, -1));
    }
}
