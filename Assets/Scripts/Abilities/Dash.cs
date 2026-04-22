using System;
using UnityEngine;
using MEC;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Dash", menuName = "Scriptable Objects/Dash")]
public class Dash : Ability // DashSO
{
    [SerializeField] Vector3 _direction;
    [SerializeField] float _distance;
    
    private CoroutineHandle _coroutine;
    private Vector3 _startPosition, _endPosition;
    private readonly string _dashCheckPhysicsLayer="DashWall"; // private const string DashCheckPhysicsLayer
   
    protected override void PlayAction(Transform transform)
    {
        _endPosition= transform.localPosition+_direction * _distance;
        _startPosition = transform.localPosition;
       _coroutine = _DashCoroutine(transform).RunCoroutine();
    }

    private IEnumerator<float> _DashCoroutine(Transform transform) // remove underscore
    {
        while (_timer <= _duration) 
        {
        transform.localPosition= Vector3.Lerp(_startPosition, _endPosition, _timer/_duration); // alternativa: Dotween
        yield return 0f;
        }
        transform.localPosition= _endPosition;
        yield return 0f;
    }

// skloni razmake da bude jedan red

    protected override bool CanExecute(Transform transform) => !Physics.Raycast(new(transform.position,transform.TransformDirection(_direction)),_distance, LayerMask.GetMask(_dashCheckPhysicsLayer));







    protected override void PlayAnimation(Animator animator)
    {
        animator.Play(_animationName,-1);
    }

    protected override void PlaySound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(_soundEffect.Clip);
    }

    protected override void StopAction(Transform transform)
    {
        Timing.KillCoroutines(_coroutine);
        transform.localPosition= _endPosition;
    }

    protected override void StopAnimation(Animator animator)
    {
         // vidi da li su ti potrebne ove metode
    }

    protected override void StopSound(AudioSource audioSource)
    {
        
    }
}
