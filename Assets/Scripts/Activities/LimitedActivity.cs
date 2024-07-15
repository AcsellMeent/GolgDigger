using System;
using TMPro;
using UnityEngine;

public abstract class LimitedActivity : Activity
{
    [SerializeField]
    protected int MaxResources;

    [SerializeField]
    protected int CurrentResources;

    [SerializeField]
    protected TMP_Text ResourcesLable;

    [SerializeField]
    protected string LableFormat;

    protected override void InitActivity()
    {
        if (CurrentResources > 0) ChangeState(true);
        UpdateLable();
    }

    protected override void OnProgressCompleted()
    {
        CurrentResources--;
        UpdateLable();
        if (CurrentResources == 0)
        {
            ChangeState(false);
            return;
        }
    }

    public void IncreaseResource(int quantity)
    {
        if (quantity < 0) throw new ArgumentOutOfRangeException("quantity < 0");

        CurrentResources += quantity;

        if (CurrentResources > MaxResources)
        {
            CurrentResources = MaxResources;
        }
        UpdateLable();
    }

    protected virtual void UpdateLable()
    {
        ResourcesLable.text = string.Format(LableFormat, CurrentResources, MaxResources);
    }

    public void AddResources(int quantity)
    {
        if (quantity < 0) throw new ArgumentOutOfRangeException("quantity < 0");
        CurrentResources += quantity;
        if (quantity == 0) return;
        if (CurrentResources > MaxResources) CurrentResources = MaxResources;
        UpdateLable();
        ChangeState(true);
    }
}
