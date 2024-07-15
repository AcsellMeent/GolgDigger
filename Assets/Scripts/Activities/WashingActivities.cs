using Zenject;

public class WashingActivities : LimitedActivity
{
    private GoldCounter _goldCounter;

    [Inject]
    public void Construct(GoldCounter goldCounter)
    {
        _goldCounter = goldCounter;
    }

    protected override void OnProgressCompleted()
    {
        base.OnProgressCompleted();
        _goldCounter.AddResource(1);
    }
}
