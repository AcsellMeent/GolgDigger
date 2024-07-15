public abstract class PlayerState : State
{
    protected PlayerComponentsProvider ComponentsProvider;

    protected PlayerState(StateMachine stateMachine, PlayerComponentsProvider componentsProvider) : base(stateMachine)
    {
        ComponentsProvider = componentsProvider;
    }
}
