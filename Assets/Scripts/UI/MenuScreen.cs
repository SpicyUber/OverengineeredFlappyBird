using System;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    [SerializeField]
    private MenuComponentInfo[] _menuComponentsInfos;
    private MenuComponent[] _menuComponents;
    

    private void Start()
    {
        InitializeMenuComponents();
    }

    private void InitializeMenuComponents()
    {
        _menuComponents = new MenuComponent[_menuComponentsInfos.Length];
        for (int i = 0; i < _menuComponentsInfos.Length; i++)
        {
            var menuComponentGameObject = Instantiate(_menuComponentsInfos[i].ComponentPrefab, transform.GetChild(0));
            _menuComponents[i] = menuComponentGameObject.GetComponent<MenuComponent>();
            _menuComponents[i].SetAction(_menuComponentsInfos[i].Action);
            _menuComponents[i].SetLabel(_menuComponentsInfos[i].Label);
        }
    }


}
