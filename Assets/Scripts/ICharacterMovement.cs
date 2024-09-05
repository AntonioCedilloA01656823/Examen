using UnityEngine;

namespace Interfaces
{
    public interface ICharacterMovement
    {
        public CharacterController controller { get; set; }

        /// <summary>
        /// Move the character in the given direction
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector3 direction);

        /// <summary>
        /// Character jumps
        /// </summary>
        public void Jump();

        /// <summary>
        /// Grounds the character
        /// </summary>
        public void GroundCharacter();

        /// <summary>
        /// Is my 
        /// </summary>
        /// <returns></returns>
        public bool IsGrounded();
    }
}
