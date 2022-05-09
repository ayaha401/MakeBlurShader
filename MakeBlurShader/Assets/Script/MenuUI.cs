using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private SettingBlurPower _settingBlurPower = null;

    void Start()
    {
        CloseUI();
    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenUI()
    {
        this.gameObject.SetActive(true);
    }
}
