
using System;
 
using UnityEngine;

[CreateAssetMenu(fileName = "MenuComponentInfo", menuName = "Scriptable Objects/MenuComponentInfo")]
public abstract class MenuComponentInfo : ScriptableObject
{
    [SerializeField] string _label;
    [SerializeField] GameObject _componentPrefab;
    public string Label {get {return _label;}}
    public GameObject ComponentPrefab { get {return _componentPrefab;}}

    protected abstract void ExecuteAction();
    public Action Action => ExecuteAction;
}
