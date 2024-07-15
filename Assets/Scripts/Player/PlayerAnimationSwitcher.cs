using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSwitcher : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private AnimationKeys _currentAnimationsKey;

    public enum AnimationKeys
    {
        IDEL,
        RUN,
        DIGGING,
        WASHING,
    }

    public readonly Dictionary<AnimationKeys, string> AnimationsList = new Dictionary<AnimationKeys, string>{
        {AnimationKeys.IDEL, "Idel"},
        {AnimationKeys.RUN, "Run"},
        {AnimationKeys.DIGGING, "Digging"},
        {AnimationKeys.WASHING, "Washing"},
    };

    private void Awake()
    {
        _currentAnimationsKey = AnimationKeys.IDEL;
    }

    public string GetAnimationName(AnimationKeys key)
    {
        return AnimationsList[key];
    }

    public void SwitchAnimation(AnimationKeys key)
    {
        _animator.SetBool(AnimationsList[_currentAnimationsKey], false);
        _currentAnimationsKey = key;
        _animator.SetBool(AnimationsList[_currentAnimationsKey], true);
    }
}
