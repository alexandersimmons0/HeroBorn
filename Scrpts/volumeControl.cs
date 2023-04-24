using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour
{
    public string volumeParameter;
    public AudioMixer mixer;
    public Slider slider;
    public float multiplier;
    public Toggle toggle;
    private bool disableToggleEvent;
    void Awake(){
        slider.onValueChanged.AddListener(SliderValueChanged);
        toggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }
    void SliderValueChanged(float value){
        mixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);
        disableToggleEvent = true;
        toggle.isOn = slider.value > slider.minValue;
        disableToggleEvent = false;
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }
    void HandleToggleValueChanged(bool enableSound){
        if(disableToggleEvent){
            return;
        }
        if(enableSound){
            slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
        }else{
            slider.value = slider.minValue;
        }
    }
    void Start(){
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }
}
