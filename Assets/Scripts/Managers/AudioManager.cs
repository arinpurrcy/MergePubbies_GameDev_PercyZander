using UnityEngine;
using UnityEngine.UI;

//<Summary> this script is used for individual volumes for different sounds. - Zander :3 <Summary>
public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource pubbieBarkAudioSource;
    public AudioSource sfxAudioSource;

    public Slider musicSlider;
    public Slider pubbieBarkSlider;
    public Slider sfxSlider;

    static private float musicVolume = 1;
    static private float pubbieBarkVolume = 1;
    static private float sfxVolume = 1;

    private void Start()
    {
        musicAudioSource.volume = musicVolume;
        pubbieBarkAudioSource.volume = pubbieBarkVolume;
        sfxAudioSource.volume = sfxVolume;

        musicSlider.value = musicVolume;
        pubbieBarkSlider.value = pubbieBarkVolume;
        sfxSlider.value = sfxVolume;
    }

    public void ChangeMusicVolume(float value)
    {
        musicAudioSource.volume = value;
        musicVolume = value;
    }

    public void ChangePubbieBarkVolume(float value)
    {
        pubbieBarkAudioSource.volume = value;
        pubbieBarkVolume = value;
    }

    public void ChangeSFXVolume(float value)
    {
        sfxAudioSource.volume = value;
        sfxVolume = value;
    }
}