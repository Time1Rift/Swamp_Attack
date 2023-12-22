using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Player _targetPlayer;
    private State _currentState;

    private void Start()
    {
        _targetPlayer = GetComponent<Enemy>().TargetPlayer;
        ResetState(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void ResetState(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_targetPlayer);
    }

    private void Transit(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter(_targetPlayer);
    }
}