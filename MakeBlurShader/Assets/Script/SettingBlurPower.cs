using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBlurPower : MonoBehaviour
{
    private Material _blurMaterial = null;

    private void Awake()
    {
        _blurMaterial = GetComponent<Image>().material;
    }

    void Start()
    {
        
    }

    public void SetLevel_1()
    {
        _blurMaterial.SetFloat("_Blur", 10.0f);
    }

    public void SetLevel_2()
    {
        _blurMaterial.SetFloat("_Blur", 30.0f);
    }

    public void SetLevel_3()
    {
        _blurMaterial.SetFloat("_Blur", 50.0f);
    }
}
