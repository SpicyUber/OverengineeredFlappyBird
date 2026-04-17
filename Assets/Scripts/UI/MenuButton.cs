using TMPro;
using UnityEngine;

public class MenuButton : MenuComponent
{
    [SerializeField] TextMeshProUGUI _tmp;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] SoundEffect _buttonClickSound;
    public override void SetLabel(string label)
    {
        _tmp.text = label;
    }

    public override void DoAction()
    {
        _audioSource.PlayOneShot(_buttonClickSound.Clip);
        base.DoAction();
    }
 
}
