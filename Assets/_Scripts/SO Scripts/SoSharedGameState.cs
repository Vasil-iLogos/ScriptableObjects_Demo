using UnityEngine;

[CreateAssetMenu]
public class SoSharedGameState : ScriptableObject {
    public delegate void DataUpdated();
    public event DataUpdated OnDataUpdated;

    private State _gameState;
    public State GameState {
        get { return _gameState; }
        set {
            _gameState = value;
            OnDataUpdated?.Invoke();
        }
    }

    public enum State {
        Play,
        GameOver
    }


}
