using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [Header("Shared Data")]
    [SerializeField] private SoSharedHumanoidStats _soSharedPlayerStats;
    [SerializeField] private SoSharedPlayerProgression _soSharedPlayerProgression;
    [SerializeField] private SoSharedGameState _soSharedGameState;
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI playerHpText;
    [SerializeField] private TextMeshProUGUI playerDamageText;
    [SerializeField] private TextMeshProUGUI playerDefenseText;
    [SerializeField] private TextMeshProUGUI playerExp;
    [SerializeField] private TextMeshProUGUI playerLevel;
    [Header("Other")]
    [SerializeField] private CanvasGroup hitRedPanel;
    [SerializeField] private GameObject gameOverPanel;

    private int lastPlayerHp;

    
    private void OnEnable() {
        lastPlayerHp = _soSharedPlayerStats.Hp;
        CheckForChanges();
        _soSharedGameState.OnDataUpdated += ShowGameOver;
        _soSharedPlayerStats.OnDataUpdated += CheckForChanges;
    }

    private void OnDisable() {
        _soSharedGameState.OnDataUpdated -= ShowGameOver;
        _soSharedPlayerStats.OnDataUpdated -= CheckForChanges;

    }

    private void ShowGameOver() {
        if (_soSharedGameState.GameState == SoSharedGameState.State.GameOver) {
            gameOverPanel.SetActive(true);
        }
    }
    private void CheckForChanges() {


        UpdateUiText();

        CheckForPlayerDamage();
    }

    private void CheckForPlayerDamage() {
       if( lastPlayerHp != _soSharedPlayerStats.Hp) {
            StartCoroutine(Hitted());
            lastPlayerHp = _soSharedPlayerStats.Hp;
        }
    }
    private IEnumerator Hitted() {

            hitRedPanel.alpha = 0.3f;
            while(hitRedPanel.alpha > 0) {
            yield return new WaitForSeconds(0.05f);
            hitRedPanel.alpha -= 0.03f;
            }
    }
    private void UpdateUiText() {


        playerHpText.text = "Player HP: " + _soSharedPlayerStats.Hp.ToString();
        playerDamageText.text = "Player Damage: " + _soSharedPlayerStats.Damage.ToString();
        playerDefenseText.text = "Player Defense: " + _soSharedPlayerStats.Defense.ToString();
        playerExp.text = "Player Exp: " + _soSharedPlayerProgression.Exp.ToString();
        playerLevel.text = "Player Level: " + _soSharedPlayerProgression.Level.ToString();

    }
}
