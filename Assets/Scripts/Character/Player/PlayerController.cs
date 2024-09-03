using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;


    public class PlayerController : MonoBehaviour
    {
        // Assign in Inspector to the layers that are considered ground
        public LayerMask groundMask;
        // CharacterMovement Reference
        private ICharacterMovement _character;

        //For collisions for sounds



        //Reference for audio control
        [SerializeField]
        private AudioController audioController;

        private void Start()
        {
            _character = new Character.Character(GetComponent<CharacterController>(), groundMask);
            audioController = GetComponentInChildren<AudioController>();    
        }

        // Update is called once per frame
        private void Update()
        {
            // Character movement vector
            Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (movementDirection != Vector3.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // TODO : Implement Sprint functionality. Right now the character jumps from 1 to 2 units, meking it look like a normal animation transition instead a smoot one usnig blend trees.
                    _character.Move(movementDirection * 2);
                }
                else
                {
                    _character.Move(movementDirection);
                }
            }

            // Changes the height position of the Character.
            if (Input.GetButtonDown("Jump"))
            {
                _character.Jump();
            }

            // Ground Character all the time
            _character.GroundCharacter();
        }


        /// <summary>
        /// Busca los triggers a los que entra unity chan y dependiendo de estos, cambia los pasos que reproduce. 
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogFormat($"Trigger with {other.gameObject.name}");

           
            if (other.CompareTag("Piso_Castillo"))
            {
                audioController._currentFloorName = "Piso_Castillo";
            }

            if (other.CompareTag("Piso_Piedra"))
            {
                audioController._currentFloorName = "Piso_Piedra";
            }
        }


    }



