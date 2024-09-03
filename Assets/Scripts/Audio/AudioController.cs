using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    
    public List<AudioClip> WoodSteps;
    public List<AudioClip> GrovelSteps;
    public List<AudioClip> GroundSteps;

    public AudioSource audioSource_step;

    public AnimationCurve curvce;
    public string _currentFloorName;


    /// <summary>
    /// Reproduce el audio dependiendo del trigger que el personaje detecte. 
    /// </summary>
    public void PlayAudioStep()
    {

        ///<summary>
        ///Se reproducen mediante los eventos de Unity que estan en las animaciones. 
        ///</summary>

        audioSource_step.PlayOneShot(GroundSteps[UnityEngine.Random.Range(0, GroundSteps.Count)]);

        switch (_currentFloorName)
        {


            case "Piso_Castillo":
                audioSource_step.PlayOneShot(WoodSteps[UnityEngine.Random.Range (0, WoodSteps.Count)]);
                break;

            case "Piso_Piedra":
                audioSource_step.PlayOneShot(GrovelSteps[UnityEngine.Random.Range(0, GrovelSteps.Count)]);
                break;

        } 

        
    }
}
