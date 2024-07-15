using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Activity : MonoBehaviour
{
    public event Action ActivityCompleted;
    public event Action<bool> ActivityActiveChanged;
    public bool Active { get; private set; }

    [SerializeField]
    protected float CurrentProgress;

    [SerializeField]
    protected float MaxProgress;

    [SerializeField]
    protected Image ProgressBar;

    private void Awake()
    {
        InitActivity();
        ProgressBar.transform.parent.gameObject.SetActive(Active);
    }

    protected virtual void InitActivity() { }

    public virtual void IncreaseProgress(float value)
    {
        ProgressBar.transform.parent.gameObject.SetActive(Active);

        if (!Active) return;

        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("value < 0");
        }

        CurrentProgress += value;

        if (CurrentProgress >= MaxProgress)
        {
            CurrentProgress = 0;
            OnProgressCompleted();
            ActivityCompleted?.Invoke();
            ProgressBar.transform.parent.gameObject.SetActive(Active);
        }
        ProgressBar.fillAmount = CurrentProgress / MaxProgress;
    }

    protected virtual void OnProgressCompleted() { }
    protected virtual void OnActiveChanged(bool active) { }

    protected void ChangeState(bool value)
    {
        Active = value;
        OnActiveChanged(value);
        ActivityActiveChanged?.Invoke(value);
    }

    private void OnValidate()
    {
        if (MaxProgress < 0)
        {
            MaxProgress = 0;
        }
    }
}
