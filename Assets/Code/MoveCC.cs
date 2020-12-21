using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace weall
{
    public class MoveCC : MonoBehaviour
    {
        public CharacterController controller;

        public float speed = 80f;

        float jumpheight = 18f;

        public GameObject calinstructions;

        [HideInInspector] public bool iusecal = false;

        Vector3 velocity;

        public float gravity = -9.81f;
        public Transform groundcheck;
        public float grounddistance = 0.4f;
        public LayerMask groundmask;
        public bool isgrounded;

        // wtf
        // the comment I waited for

        SelectionManager sm;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            sm = GameObject.FindObjectOfType<SelectionManager>();
        }
        void Update()
        {
            isgrounded = Physics.CheckSphere(groundcheck.position,grounddistance,groundmask);

            if(isgrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if(Input.GetKeyDown(KeyCode.Space) && isgrounded)
            {
                velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime); 

            if (Input.GetKeyDown(KeyCode.C) && iusecal != true)
            {
                
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Debug.Log("Worked");
                calinstructions.SetActive(true);
                iusecal = true;

            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                calinstructions.SetActive(false);
                iusecal = false;
            }

        }

    }
}
