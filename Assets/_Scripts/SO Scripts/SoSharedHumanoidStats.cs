using UnityEngine;

[CreateAssetMenu]
public class SoSharedHumanoidStats : ScriptableObject {

    public delegate void DataUpdated();
    public event DataUpdated OnDataUpdated;

    [SerializeField] private SoBlueprintHumanoidStats _defaultBlueprint;
    public SoBlueprintHumanoidStats DefaultBlueprint { get { return _defaultBlueprint; } set { _defaultBlueprint = value; } }
    
    [SerializeField] private string _humanoidName;
    public string HumanoidName {
        get { return _humanoidName; }
        set {
            _humanoidName = value;
            OnDataUpdated?.Invoke();
        }
    }


    [SerializeField] private int _hp;
    public int Hp {
        get { return _hp; }
        set {
            _hp = value;
            OnDataUpdated?.Invoke();
        }
    }


    [SerializeField] private int _damage;
    public int Damage {
        get { return _damage; }
        set {
            _damage = value;
            OnDataUpdated?.Invoke();
        }
    }


    [SerializeField] private int _defense;
    public int Defense {
        get { return _defense; }
        set {
            _defense = value;
            OnDataUpdated?.Invoke();
        }
    }

    public void SetFromBlueprint(SoBlueprintHumanoidStats blueprint) {
        HumanoidName = blueprint.HumanoidName;
        Hp = blueprint.Hp;
        Damage = blueprint.Damage;
        Defense = blueprint.Defense;
    }
    public void SetFromBlueprint() {
        HumanoidName = DefaultBlueprint.HumanoidName;
        Hp = DefaultBlueprint.Hp;
        Damage = DefaultBlueprint.Damage;
        Defense = DefaultBlueprint.Defense;
    }

}
