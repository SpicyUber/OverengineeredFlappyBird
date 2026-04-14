using UnityEngine;

 
public abstract class Effect : ScriptableObject
{

    public abstract void Play(Transform transform, float? durationOverride);

    public void Play(Transform transform) => Play(transform, null);



}
