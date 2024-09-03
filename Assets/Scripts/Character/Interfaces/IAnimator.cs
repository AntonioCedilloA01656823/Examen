using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{

    /// <summary>
    /// Interfaz de animación para animator/blendtree
    /// </summary>
    public interface IAnimator 
    {
        public Animator Animator { get; set; }

        public void setBool(string name, bool value);
        public void setFloat(string name, float value);
        public void setInteger(string name, int value);
        public void settrigger(string name);

        public void playAnimationByHash(int hash);



    }
}

