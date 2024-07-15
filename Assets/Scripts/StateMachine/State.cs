public abstract class State
{
    public State(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }
    protected StateMachine StateMachine;
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
