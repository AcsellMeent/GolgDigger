using UnityEngine;
public class DiggingActivities : Activity
{
    [SerializeField]
    private Conveyor _conveyor;

    protected override void InitActivity()
    {
        ChangeState(true);
    }

    protected override void OnProgressCompleted()
    {
        _conveyor.LoadSand();
    }
}
