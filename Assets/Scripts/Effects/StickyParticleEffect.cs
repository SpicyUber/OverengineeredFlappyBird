using UnityEngine;
using MEC;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "StickyParticleEffect", menuName = "Scriptable Objects/Effects/StickyParticleEffect")]
public class StickyParticleEffect : Effect
{
    [SerializeField] ParticleSystem Particle;

    [SerializeField] float Duration;
    public override void Play(Transform transform, float? durationOverride)
    {
        float duration = durationOverride ?? Duration;

        _EffectCoroutine(transform,duration).RunCoroutine();

    }

    private IEnumerator<float> _EffectCoroutine(Transform transform,float duration)
    {
        var effect = Instantiate(Particle,transform);
        effect.Play();
        yield return Timing.WaitForSeconds(duration);
        effect.Stop();
        Destroy(effect);
    }

   
}
