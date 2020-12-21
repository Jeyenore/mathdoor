using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weall
{
    public class MouseLookCC : MonoBehaviour
    {
        public float mousespeed = 150f;
        public Transform player;
        private float x = 0;
        private float y = 0;
        public Transform examinetarget;
        [HideInInspector] public SelectionManager SM;

        private void Awake()
        {
            Cursor.visible = true;
            SM = GameObject.FindObjectOfType<SelectionManager>();
        }

        void Update()
        {

            
                x += Input.GetAxis("Mouse X") * mousespeed * Time.deltaTime;
                y -= Input.GetAxis("Mouse Y") * mousespeed * Time.deltaTime;


                y = Mathf.Clamp(y, -90f, 90f);
                transform.localRotation = Quaternion.Euler(y, 0f, 0f);
                player.transform.localRotation = Quaternion.Euler(0, x, 0);
            
           


        }
    }
}

