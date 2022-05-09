using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private MenuUI _menuUI = null;
    [SerializeField] private GameObject _blurImageObj = null;

    void Start()
    {
        _blurImageObj.SetActive(false);
    }

    public void OpenMenuUI()
    {
        _menuUI.OpenUI();
        CloseUI();
    }

    public void OpenUI()
    {
        this.gameObject.SetActive(true);
        _blurImageObj.SetActive(true);
    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }
}
