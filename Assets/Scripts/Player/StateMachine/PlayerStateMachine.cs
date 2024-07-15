using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField]
    private PlayerComponentsProvider _playerComponentsProvider;

    protected override void InitStates()
    {
        States = new State[]{
            new PlayerIdelState(this, _playerComponentsProvider),
            new PlayerRunState(this, _playerComponentsProvider),
            new PlayerActivityState(this, _playerComponentsProvider),
        };
    }
}
