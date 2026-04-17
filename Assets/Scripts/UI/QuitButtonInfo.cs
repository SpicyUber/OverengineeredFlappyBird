using UnityEngine;

[CreateAssetMenu(fileName = "QuitButtonInfo", menuName = "Scriptable Objects/QuitButton")]
public class QuitButtonInfo : MenuComponentInfo
{
    protected override void ExecuteAction()
    {
        Application.Quit();
    }
}
