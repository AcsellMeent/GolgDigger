using System.Linq;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State[] States;
    protected State CurrentState;

    private void Awake()
    {
        InitStates();
        StartState();
    }

    protected abstract void InitStates();
    protected virtual void StartState()
    {
        if (States.Length == 0) return;
        CurrentState = States[0];
        CurrentState!.Enter();
    }

    private void Update()
    {
        CurrentState?.Update();
    }

    public void SwitchState<T>() where T : State
    {
        var state = States.FirstOrDefault(s => s is T);
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}
