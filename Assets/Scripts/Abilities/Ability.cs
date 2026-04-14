using System;
using UnityEngine;

 
public abstract class Ability : ScriptableObject
{
    [SerializeField] protected AnimationClip _animation;
    [SerializeField] protected SoundEffect _soundEffect;
    [SerializeField][Range(0.0f, 1f)] protected float _windUpPercentage;
    [SerializeField][Range(0.0f, 1f)] protected float _uninterruptablePercentage;
    [SerializeField] protected float _baseDuration;
    protected float _duration;

    private float _startTime=0f;
    protected float _timer=>Time.time-_startTime;
   
    public void Activate(Transform activatorTransform,Animator activatorAnimator,AudioSource activatorAudioSource,Stats activatorStats) {

        SetStartTime();

        SetAbilityStats(activatorStats);
       
        PlayAnimation(activatorAnimator);

        PlayAction(activatorTransform);

        PlaySound(activatorAudioSource);
    
    }

    private void SetStartTime()
    {
       _startTime = Time.time;
    }

    protected virtual void SetAbilityStats(Stats stats) => _duration = _baseDuration / stats.Speed;

    public bool TryInterrupt(Transform transform, Animator animator, AudioSource audioSource)
    {
        if (_timer <= _uninterruptablePercentage * _duration) 
            return false;

        StopAnimation(animator);

        StopAction(transform);

        StopSound(audioSource);

        return true;
    }

  

    protected abstract void PlaySound(AudioSource audioSource);
    protected abstract void PlayAction(Transform transform);
    protected abstract void PlayAnimation(Animator animator);
    protected abstract void StopSound(AudioSource audioSource);
    protected abstract void StopAction(Transform transform);
    protected abstract void StopAnimation(Animator animator);
}
