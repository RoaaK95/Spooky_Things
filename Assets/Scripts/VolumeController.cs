using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _music, _sfxButton, _targetAudioSource;
    [SerializeField]
    private AudioClip _goodSfx, _badSfx;

    void Start()
    {
        _music.volume = PlayerPrefs.GetFloat("MusicVolume");
        _sfxButton.volume = PlayerPrefs.GetFloat("SfxVolume");
        _targetAudioSource.volume = PlayerPrefs.GetFloat("SfxVolume");
    }

    public void PLayTargetSfx(bool isGoodPickup)
    {

        if (isGoodPickup)
        {
            _targetAudioSource.PlayOneShot(_goodSfx);
        }
        else
        {
            _targetAudioSource.PlayOneShot(_badSfx);
        }

    }
}
