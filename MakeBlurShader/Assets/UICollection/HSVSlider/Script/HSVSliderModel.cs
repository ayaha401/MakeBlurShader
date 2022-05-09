using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace UICollection.HSVSlider
{
    public class HSVSliderModel : MonoBehaviour
    {
        [SerializeField] private Slider _H_Slider = null;
        [SerializeField] private Slider _S_Slider = null;
        [SerializeField] private Slider _V_Slider = null;

        [Header("StartHSV_Value")]
        [SerializeField, Range(0.0f, 0.999f)] private float _h_Value = 0.0f;
        [SerializeField, Range(0.0f, 1.0f)] private float _s_Value = 1.0f;
        [SerializeField, Range(0.0f, 1.0f)] private float _v_Value = 1.0f;

        public event Action<Color> SetImageColorEvent = null;
        public event Action<float, float, float> SetSliderBGEvent = null;

        void Start()
        {
            SetSlider();
            SetImageColorEvent(GetColor());
            SetSliderBGEvent(_h_Value, _s_Value, _v_Value);
        }

        private void SetSlider()
        {
            _H_Slider.value = _h_Value;
            _S_Slider.value = _s_Value;
            _V_Slider.value = _v_Value;
        }

        public void GetH()
        {
            _h_Value = _H_Slider.value;
            SetImageColorEvent(GetColor());
            SetSliderBGEvent(_h_Value, _s_Value, _v_Value);
        }

        public void GetS()
        {
            _s_Value = _S_Slider.value;
            SetImageColorEvent(GetColor());
            SetSliderBGEvent(_h_Value, _s_Value, _v_Value);
        }

        public void GetV()
        {
            _v_Value = _V_Slider.value;
            SetImageColorEvent(GetColor());
            SetSliderBGEvent(_h_Value, _s_Value, _v_Value);
        }

        public Color GetColor()
        {
            return Color.HSVToRGB(_h_Value, _s_Value, _v_Value);
        }
    }
}

