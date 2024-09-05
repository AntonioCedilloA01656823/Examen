using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnim : MonoBehaviour
{

    /// <summary>
    /// Private variable of animator
    /// </summary>
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {

        // Getting the animator component of the character, in this Case skeleton. 
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Thyra has an animator where she can be in its idle animation or attack.
    /// The code will search for a collision, where it will change her idle animation
    /// to it attack animation when a game object collides with it.  
    /// </summary>
    /// 

    //Activates when collision with other game object
    private void OnTriggerEnter(Collider other)
    {
        //Plays animation if there is one
        if (anim != null)
        {
            anim.Play("Base Layer.Attack", 0);
        }
    }
}


