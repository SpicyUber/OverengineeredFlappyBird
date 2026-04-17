using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MessageBox : SingletonPersistent<MessageBox>
{
    GameObject _msgDisplay;
    public void DisplayMessage(string message,float duration)
    {
        if(_msgDisplay)Destroy(_msgDisplay);
        _msgDisplay = GameObject.Instantiate(new GameObject(), this.transform);
        _msgDisplay.AddComponent<TextMeshProUGUI>().text = message;
        StartCoroutine(MessageCoroutine(duration));
    }

    IEnumerator MessageCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);

        if( _msgDisplay) Destroy(_msgDisplay);

    }
}
