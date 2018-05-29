using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SkillSlider : MonoBehaviour {

    public int MaxSliderValue = 500;

    public void SliderProgress()
    {
        slider = (slider == null) ? GetComponent<Image>() : slider;
        slider.fillAmount = Calcul.ValueToPercentage( Score.Instance.GetHighscore, MaxSliderValue ) / 100;
    }
	
	void LateUpdate () {
        SliderProgress();
	}


    private Image slider;
}
