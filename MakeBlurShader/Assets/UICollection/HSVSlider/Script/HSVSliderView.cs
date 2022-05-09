using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UICollection.HSVSlider
{
    public class HSVSliderView : MonoBehaviour
    {
        [SerializeField] private Image _S_SliderBGImage = null;
        [SerializeField] private Image _V_SliderBGImage = null;
        [Space]
        [SerializeField] private Image _sampleColorImage = null;
        
        void Start()
        {
            
        }

        public void SetImageColor(Color col)
        {
            _sampleColorImage.color = col;
        }

        public void SetSliderBG(float h, float s, float v)
        {
            _S_SliderBGImage.material.SetFloat("_Hue", h);
            _S_SliderBGImage.material.SetFloat("_Val", v);

            _V_SliderBGImage.material.SetFloat("_Hue", h);
            _V_SliderBGImage.material.SetFloat("_Sat", s);
        }
    }
}

