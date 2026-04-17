

using System;
using UnityEngine;

public abstract class MenuComponent : MonoBehaviour
{
    private Action _action;
    public abstract void SetLabel(string label);

    public void SetAction(Action action)=>_action=action;
    public virtual void DoAction() => _action.Invoke();

}
