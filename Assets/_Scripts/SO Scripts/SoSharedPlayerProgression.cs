using UnityEngine;

[CreateAssetMenu]
public class SoSharedPlayerProgression : ScriptableObject {
    public delegate void DataUpdated();
    public event DataUpdated OnDataUpdated;

    [SerializeField] private SoBlueprintExpTable _blueprintExpTable;

    [SerializeField] private int _exp;
    public int Exp {
        get { return _exp; }
        set {
            _exp = value;
            OnDataUpdated?.Invoke();
        }
    }
    public int Level { get { return GetLevel(); } }

    public void Reset() {
        Exp = 0;
    }
    private int GetLevel() {
        int level = 0;
        for (int i = 0; i < _blueprintExpTable.ExpTable.Count; i++) {
            if (_exp >= _blueprintExpTable.ExpTable[i]) {
                level++;
            }
        }
        return level;
    }
}
