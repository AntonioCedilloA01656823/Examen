using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface ICharacterMovement
    {
        public CharacterController controller { get; set; }

        /// <summary>
        /// Movimiento de personaje en la dirección indicada
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector3 direction);

        /// <summary>
        /// Salto del personaje
        /// </summary>
        public void Jump();

        /// <summary>
        /// Pon el personaje en tierra
        /// </summary>
        public void GroundCharacter();

        /// <summary>
        /// Personaje en tierra?
        /// </summary>
        /// <returns></returns>
        public bool IsGrounded();
    }
}
