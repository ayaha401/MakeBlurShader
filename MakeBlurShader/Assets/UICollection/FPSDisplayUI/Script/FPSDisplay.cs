using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    private const float SPAN =1.0f;

    private TextMeshProUGUI _fpsText = null;

    private int _frameCount = 0;
    private float _elapsedTime = 0.0f;
    
    void Awake()
    {
        _fpsText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _frameCount++;
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= SPAN)
        {
            float fps = (float)_frameCount/_elapsedTime;
            _fpsText.text = $"FPS:{fps.ToString("F2")}";

            _frameCount = 0;
            _elapsedTime = 0.0f;
        }
    }
}
