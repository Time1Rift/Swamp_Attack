using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    protected Player TargetPlayer;

    public bool NeedTransit { get; protected set; }

    public State NextState => _nextState;

    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(Player targetPlayer) => TargetPlayer = targetPlayer;
}