 
using UnityEngine;
 

[CreateAssetMenu(fileName = "PlayButtonInfo", menuName = "Scriptable Objects/PlayButtonInfo")]
public class PlayButtonInfo : MenuComponentInfo
{
    [SerializeField]float delayInSeconds;
    protected override void ExecuteAction() => LevelSequencer.Instance.GoToNextLevelDelayed(delayInSeconds);



}
