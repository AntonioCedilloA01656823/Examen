using System;
using UnityEngine;
using UnityEngine.Playables;

namespace UnityAnimationEvents
{
    /// <summary>
    /// This class exemplifies how to play a Timeline using the PlayableDirector component instead of playing it as soon as the scene starts.
    /// </summary>
    public class TimelineController : MonoBehaviour
    {
        /*
         * The PlayableDirector component is used to control the playback of PlayableAssets, such as TimelineAssets.
         * It allows you to play, pause, stop, and seek through the Timeline, as well as trigger events and set the time.
         *
         * https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.html
         *
         * Remember that we need to unckeck the "Play on Awake" option in the PlayableDirector component to avoid playing
         * the Timeline as soon as the scene starts.
         */

        // Reference to the PlayableDirector component
        [SerializeField] private PlayableDirector _playableDirector;

        //camaras


        private void Update()
           
        {
            
            // Inicia timeline con tecla Q
            if (Input.GetKeyDown(KeyCode.Q))
                PlayTimeline();
        }

        /// <summary>
        /// Reproduce el timeline (en este caso la cutscene)
        /// </summary>
        public void PlayTimeline()
        {
            Debug.LogFormat($"*** Playing Timeline {_playableDirector.name} from code");
            // Starts a Timeline when the function is called
            _playableDirector.Play();
        }
    }
}