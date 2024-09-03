using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbientAudioController : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;

    // Update is called once per frame
    void Update()
    {
        float currentVol;
        mixerGroup.audioMixer.GetFloat("MusicVolume", out currentVol);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LeanTween.value(currentVol, -80, 1).setOnUpdate((float val) =>
            {
                mixerGroup.audioMixer.SetFloat("MusicVolume", val);
            });
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LeanTween.value(currentVol, -40, 1).setOnUpdate((float val) =>
            {
                mixerGroup.audioMixer.SetFloat("MusicVolume", val);
            });

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LeanTween.value(currentVol, 0, 1).setOnUpdate((float val) =>
            {
                mixerGroup.audioMixer.SetFloat("MusicVolume", val);
            });

        }


    }
    
}
