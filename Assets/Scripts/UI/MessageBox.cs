using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MessageBox : Singleton<MessageBox>
{
    GameObject _scoreDisplay;
    public void DisplayScore()
    {
        if(_scoreDisplay)Destroy(_scoreDisplay);
        _scoreDisplay = GameObject.Instantiate(new GameObject(), this.transform);
        _scoreDisplay.AddComponent<TextMeshProUGUI>().text = $"GAME OVER! SCORE {(int)Rail.Instance.CurrentLevelU}";
    }
}
