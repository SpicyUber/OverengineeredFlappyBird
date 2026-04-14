using System;
using UnityEngine;
using UnityEngine.Scripting;

[CreateAssetMenu(fileName = "SoundEffect", menuName = "Scriptable Objects/SoundEffect")]
public class SoundEffect : ScriptableObject
{
    [SerializeField]
   
    private AudioClip _clip;

    [SerializeField]
    
    private string _credits;

    public AudioClip Clip { get { return _clip; } }
    public string Credits { get { return _credits; } }
}
