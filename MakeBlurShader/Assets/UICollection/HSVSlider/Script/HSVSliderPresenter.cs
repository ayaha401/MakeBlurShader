using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UICollection.HSVSlider
{
    public class HSVSliderPresenter : MonoBehaviour
    {
        [SerializeField] private HSVSliderModel model = null;
        [SerializeField] private HSVSliderView view = null;

        void Awake()
        {
            model.SetImageColorEvent += view.SetImageColor;
            model.SetSliderBGEvent += view.SetSliderBG;
        }
    }
}

