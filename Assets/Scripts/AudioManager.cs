using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Slider _musicSlider, _sfxSlider;
    [SerializeField]
    private AudioSource _music, _sfx;
    private float _defaultVolume = 0.5f;
    private void Awake()
    {
        _musicSlider.value = _defaultVolume;
        _sfxSlider.value = _defaultVolume;
    }
    void Start()
    {
        _music.volume = _musicSlider.value;
        _sfx.volume = _sfxSlider.value;
    }
    public void SetVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", _music.volume);
        PlayerPrefs.SetFloat("SfxVolume", _sfx.volume);
    }

}
