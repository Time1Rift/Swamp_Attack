using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions = new();

    protected Player TargetPlayer;

    public void Enter(Player targetPlayer)
    {
        if (enabled == false)
        {
            TargetPlayer = targetPlayer;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(TargetPlayer);
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }        
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
            if (transition.NeedTransit)
                return transition.NextState;

        return null;
    }
}