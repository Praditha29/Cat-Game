using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
{
    //to access audio mixer
    [SerializeField] private AudioMixer myMixer;
    //to access volume slider
    [SerializeField] private Slider musicSlider;

    public void SetMusicVolume()
    {
        //get slider value of music playing
        float volume = musicSlider.value;
        //set volume to slider value
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
    }
}
