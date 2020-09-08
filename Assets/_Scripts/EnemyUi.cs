using TMPro;
using UnityEngine;

public class EnemyUi : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI statsText;
    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI hitText;

    private SoSharedHumanoidStats _enemySharedStats;
    private SoSharedAttackTime _enemySharedAttackTime;

    private int lastHpValue;
    private void OnEnable() {
        if (GetComponentInParent<Enemy>() != null && GetComponentInParent<Enemy>().sharedEnemyStats != null && GetComponentInParent<Enemy>().sharedEnemyAttackTime != null) {
            SetSharedStats(GetComponentInParent<Enemy>().sharedEnemyStats, GetComponentInParent<Enemy>().sharedEnemyAttackTime);
            _enemySharedStats.OnDataUpdated += CheckForChanges;
            _enemySharedAttackTime.OnDataUpdated += CheckForChanges;
        }
        CheckForChanges();
    }
    private void OnDisable() {
        if(_enemySharedStats != null) {
            _enemySharedStats.OnDataUpdated -= CheckForChanges;
            _enemySharedAttackTime.OnDataUpdated -= CheckForChanges;
        }
    }
 
    public void SetSharedStats(SoSharedHumanoidStats enemySharedStats, SoSharedAttackTime enemySharedAttackTime ) {
        _enemySharedStats = enemySharedStats;
        _enemySharedAttackTime = enemySharedAttackTime;
        lastHpValue = _enemySharedStats.Hp;
    }
    private void CheckForChanges() {
        if (_enemySharedStats == null) {
            return;
        }

        UpdateUI();
    }
    private void UpdateUI() {
        statsText.text ="Name: "+ _enemySharedStats.HumanoidName + " HP: " + _enemySharedStats.Hp + " Damage: " + _enemySharedStats.Damage + " Defense: " + _enemySharedStats.Defense;

        if (_enemySharedStats.Hp > 0) {
            int timeUntilNextAtk = Mathf.RoundToInt(_enemySharedAttackTime.TimeUntilAttack);
            atkText.text ="Attack in: " + timeUntilNextAtk.ToString();
            if (timeUntilNextAtk >= 4) {
                atkText.color = Color.grey;
            } else 
                if (timeUntilNextAtk >= 2) {
                    atkText.color = Color.yellow;
                } else {
                    atkText.color = Color.red;

            }

            if (_enemySharedStats.Hp != lastHpValue) {
                hitText.text = (lastHpValue - _enemySharedStats.Hp).ToString();
                hitText.alpha = 1;
                lastHpValue = _enemySharedStats.Hp;

            }
        } else {
            Destroy(this.gameObject);
        }

        if (hitText.alpha > 0) {
            hitText.alpha -= Time.deltaTime;
        }

    }
}
