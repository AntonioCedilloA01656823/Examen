using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{

    /// <summary>
    /// Controlador de animación, usado para cambiar animaciones dependiendo de input usario
    /// </summary>
    public class AnimationController : IAnimator
    {
        public UnityEngine.Animator Animator { get; set; }

        /// <summary>
        /// Setea valores para el blend tree
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>

       public void setBool(string name, bool value)
        {
            Animator.SetBool(name, value);
        }

        public void setFloat(string name, float value)
        {
            Animator.SetFloat(name, value);
        }

        public void setInteger(string name, int value)
        {
            Animator.SetInteger(name, value);
        }
        public void settrigger(string name)
        {
            Animator.SetTrigger(name);
        }

        /// <summary>
        /// Reproduce la animación por hash
        /// </summary>
        /// <param name="hash"></param>
        public void playAnimationByHash(int hash)
        {
            Animator.Play(hash);
        }
    }

}

