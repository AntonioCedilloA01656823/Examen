using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayThyraAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    /// <summary>
    /// Private variable of animator
    /// </summary>
    private Animator anim;

    void Start()
    {
        // Getting the animator component of the character, in this Case thyra. 
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame


    void Update()
    {
    }

    /// <summary>
    /// Thyra has an animator where she can be in her idle animation or jump.
    /// The code will search for a collision, where it will change her idle animation
    /// to her jump animation when a game object collides with it.  
    /// </summary>
    /// 

    //Activates when collision with other game object
    private void OnTriggerEnter(Collider other)
    {
        //Plays animation if there is one
        if (anim != null)
        {
            anim.Play("Base Layer.Jumping", 0);
        }
    }
}
