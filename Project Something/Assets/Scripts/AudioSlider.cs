using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour {
    public Slider slider;
    public AudioMixer target;
    public string paramName;

	// Use this for initialization
	void Start () {
        float value;
        target.GetFloat(paramName, out value);
        slider.value = value;

        slider.onValueChanged.AddListener(delegate { ChangeValue(slider.value); });
	}
	
	public void ChangeValue (float value)
    {
        target.SetFloat(paramName, value);
    }
}
