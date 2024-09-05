using Interfaces;
using UnityEngine;

namespace Character
{
    public class Character : ICharacterMovement
    {
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float playerSpeed = 5f;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;
        public CharacterController controller { get; set; }
        public LayerMask groundMask;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="characterController"></param>
        /// <param name="groundLayerMask"></param>
        public Character(CharacterController characterController, LayerMask groundLayerMask)
        {
            controller = characterController;
            groundMask = groundLayerMask;
        }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        protected Character()
        {

        }

        public void Move(Vector3 direction)
        {
            // Move the character in the given direction
            controller.Move(direction * Time.deltaTime * playerSpeed);

            // Rotates character to the movement direction
            if (direction != Vector3.zero)
            {

                if (direction.z >= 0)
                {
                    controller.transform.forward = direction;
                }
                else
                {
                    controller.transform.forward = -direction;

                }

            }
        }

        public void Jump()
        {
            if (IsGrounded()) 
            { 
                return;
            }
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            controller.Move(playerVelocity * Time.deltaTime);
            
        }

        public void GroundCharacter()
        {
            // If the character is grounded, return
            if (IsGrounded() && playerVelocity.y < 0)
            {
                playerVelocity.y = 0;
                return;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        public bool IsGrounded()
        {
            Debug.DrawRay(controller.transform.position, Vector3.down * 0.15f, Color.red);

            return Physics.Raycast(controller.transform.position, Vector3.down, out RaycastHit hit, 0.15f, groundMask);
        }

    }
}
