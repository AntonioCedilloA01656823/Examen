using Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        LayerMask groundMask;
        private ICharacterMovement _character;
        private Animator animator;
        private bool hitRay;
        public float searchRadius;
        public UnityEvent lightCandle;
        private bool isGrounded = false;
        private float lastFootstepTime = 0f;


        // Distance and time per footstep
        public float initialHeightOffset = 0.5f;
        public float groundCheckDistance = 0.5f;
        public float raycastHeightOffset = 0.1f;
        public float footstepDelay = 0.5f;

        // Audio Clips for footsteps
        public AudioSource audioSource;
        public AudioClip stoneFootstep;
        public AudioClip carpetFootstep;
        public AudioClip woodFootstep;

        public void StopInteraction()
        {
            animator.SetBool("Interact", false);
        }

        private void OnTriggerEnter(Collider other)
        {
            animator.SetBool("Interact", true);
        }

        void Start()
        {
            _character = new Character.Character(GetComponent<CharacterController>(), groundMask);
            animator = GetComponent<Animator>();
            hitRay = false;

            // Minimum distance to the candle for it to trigger
            searchRadius = 3.5f;
        }


        void Update()
        {
            // Get input from player controller
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Set direction of the movement
            Vector3 movementDirection = new Vector3(horizontal, 0, vertical);

            // Pass values to the animator for the blend tree
            animator.SetFloat("xSpeed", horizontal);
            animator.SetFloat("ySpeed", vertical);

            if (movementDirection != Vector3.zero && !hitRay)
            {
                // Sprint
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _character.Move(movementDirection * 2f);
                    animator.SetFloat("xSpeed", Input.GetAxis("Horizontal") * 2);

                }
                else
                {
                    _character.Move(movementDirection);
                }
            }

            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                _character.Jump();
            }

            _character.GroundCharacter();


            

            // Search collider in the ground
            Vector3 raycastOrigin = transform.position + Vector3.up * raycastHeightOffset;
            RaycastHit hit;


            // if the player is currently touching the ground
            if (Physics.Raycast(raycastOrigin, -Vector3.up, out hit, groundCheckDistance))
            {

                // if the player is touching a known material
                if (hit.collider.tag == "Stone" || hit.collider.tag == "Carpet" || hit.collider.tag == "Wood")
                {
                    isGrounded = true;

                    // if the player is moving and the last step was some time ago
                    if (isGrounded && (horizontal != 0 || vertical != 0) && Time.time - lastFootstepTime >= footstepDelay)
                    {

                        // Play sound animation
                        PlayFootstepSound(hit.collider.tag);
                        lastFootstepTime = Time.time;
                    }
                }
                else
                {
                    isGrounded = false;
                }
            }
            else
            {
                isGrounded = false;
            }


        }

        // Trigger lighting and pass to animator to start magic animation
        public void finishedLightning()
        {
            animator.SetBool("isLightingCandle", false);
        }

        // Based on the surface the player is standing play a corresponding sound
        void PlayFootstepSound(string surfaceTag)
        {
            if (audioSource != null)
            {
                if (surfaceTag == "Stone" && stoneFootstep != null)
                {
                    audioSource.clip = stoneFootstep;
                    audioSource.Play();
                }
                else if (surfaceTag == "Carpet" && carpetFootstep != null)
                {
                    audioSource.clip = carpetFootstep;
                    audioSource.Play();
                }
                else if (surfaceTag == "Wood" && woodFootstep != null)
                {
                    audioSource.clip = woodFootstep;
                    audioSource.Play();
                }
            }
        }
    }
}