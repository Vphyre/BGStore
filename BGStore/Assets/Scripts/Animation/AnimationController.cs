using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _animatedObject;
    public GameObject AnimatedObject { get => _animatedObject; set => _animatedObject = value; }
    private Animator animator;
    private float xScaleValue = 0;
    private string parameterNameToSet;

    private void Awake()
    {
        xScaleValue = _animatedObject.transform.localScale.x;
        animator = GetComponent<Animator>();
    }
    public void FlipSprite(bool isOnRight)
    {
        if (isOnRight)
        {
            _animatedObject.transform.parent.localScale = new Vector3(xScaleValue, _animatedObject.transform.parent.localScale.y, _animatedObject.transform.parent.localScale.z);
            return;
        }
        _animatedObject.transform.parent.localScale = new Vector3(-xScaleValue, _animatedObject.transform.parent.localScale.y, _animatedObject.transform.parent.localScale.z);
    }
    public void TurnOnBoolParameter(string parameterName)
    {
        animator.SetBool(parameterName, true);
    }
    public void TurnOffBoolParameter(string parameterName)
    {
        animator.SetBool(parameterName, false);
    }
    public void TurnOnTriggerParameter(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
    public void PlaySpecificAnimation(string animationName)
    {
        animator.Play(animationName);
    }
    public void ResetSpecificAnimation(string animationName)
    {
        animator.Play(animationName, -1, 0f);
    }
    public void StopAnimation()
    {
        animator.StopPlayback();
    }
    public void SetAnimationSpeed(float newSpeed)
    {
        animator.speed = newSpeed;
    }
    public void SetSpecificParameterName(string parameterName)
    {
        parameterNameToSet = parameterName;
    }
    public void SetFloatParameter(float parameterValue)
    {
        animator.SetFloat(parameterNameToSet, parameterValue);
    }
}



