using System;
using System.Collections.Generic;
using UnityEngine;
using AnimationKeys = PlayerAnimationSwitcher.AnimationKeys;

public class PlayerActivitiesAnimations : MonoBehaviour
{
    private Dictionary<Type, AnimationKeys> _animationKeys;

    private void Awake()
    {
        _animationKeys = new Dictionary<Type, AnimationKeys> {
            { typeof(DiggingActivities), AnimationKeys.DIGGING },
            { typeof(WashingActivities), AnimationKeys.WASHING },
            { typeof(FurnaceActivities), AnimationKeys.DIGGING },
        };
    }

    public AnimationKeys GetAnimationKeys(Activity activities)
    {
        return _animationKeys.GetValueOrDefault(activities.GetType());
    }
}
