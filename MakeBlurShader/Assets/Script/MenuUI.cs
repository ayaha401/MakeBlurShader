using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private MenuButton _menuButton = null;
    [SerializeField] private GameObject _blurImageObj = null;

    void Start()
    {
        CloseUI();
    }

    public void CloseUI()
    {
        _menuButton.OpenUI();
        _blurImageObj.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void OpenUI()
    {
        this.gameObject.SetActive(true);
    }
}
