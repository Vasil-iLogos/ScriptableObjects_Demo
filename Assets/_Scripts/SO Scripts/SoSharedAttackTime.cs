using UnityEngine;

[CreateAssetMenu]
public class SoSharedAttackTime : ScriptableObject {
    public delegate void DataUpdated();
    public event DataUpdated OnDataUpdated;

    [SerializeField] private float _time;
    public float TimeUntilAttack {
        get { return _time; }
        set { _time = value; OnDataUpdated?.Invoke(); }
    }

}
