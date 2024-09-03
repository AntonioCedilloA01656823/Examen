using System.Collections;
using System.Collections.Generic;
using Interfaces;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

namespace Character
{

    /// <summary>
    /// Clase de pesonaje. Tiene los datos para el movimiento del mismo 
    /// Tiene los metodos de movimiento, salto y checar si esta en tierra dados por la interfaz. 
    /// Toma en cuenta gravedad, velocidad y altura de salto para el movimiento.
    /// Tiene los valores para cambiar los valores en el blendtree/animator
    /// </summary>
    public class Character : ICharacterMovement
    {
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float playerSpeed = 2.0f;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;

        private readonly AnimationController _animator;

        private const string FrontWalkAnimation = "Forward";
        private const string SideWalkAnimation = "Side";
        private const string JumpWalkAnimation = "Jump";


        public CharacterController controller { get; set; }
        public LayerMask groundMask;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="characterController"></param>
        /// <param name="groundLayerMask"></param>
        /// 

        private readonly int _randomHash = Animator.StringToHash(name: "JUMP00");
        public Character(CharacterController characterController, LayerMask groundLayerMask)
        {
            controller = characterController;
            groundMask = groundLayerMask;

            _animator = new AnimationController();
            _animator.Animator = controller.GetComponentInChildren<Animator>();
        }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        protected Character()
        {

        }

        /// <summary>
        /// Mueve al personaje en la dirección dada
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector3 direction)
        {
            // Move the character in the given direction
            controller.Move(direction * Time.deltaTime * playerSpeed);

            //Rotating corrected
            controller.transform.Rotate(Vector3.up, direction.x);

            //Plays animation
            _animator.setFloat(FrontWalkAnimation, direction.z);
            _animator.setFloat(SideWalkAnimation, direction.x);
        }

        public void Jump()
        {
            // If is already jumping, return
            if (!IsGrounded() || playerVelocity.y > 0)
                return;

            // Moves the character in the given direction
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            controller.Move(playerVelocity * Time.deltaTime);

        }

        public void GroundCharacter()
        {
            if (IsGrounded() && playerVelocity.y < 0)
            {
                // Moves the player down
                playerVelocity.y = 0f;
                return;
            }
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        public bool IsGrounded()
        {
            // This offers innacurate results
            // return controller.isGrounded;

            // Implement a raycast to check if the character is grounded
            // Draw a raycast from the player's position to the ground to check the distance
            Debug.DrawRay(controller.transform.position, Vector3.down * 0.15f, Color.red);

            // Check if the raycast hits the ground layer
            return Physics.Raycast(controller.transform.position, Vector3.down, out RaycastHit hit, 0.15f, groundMask);

        }
    }
}
