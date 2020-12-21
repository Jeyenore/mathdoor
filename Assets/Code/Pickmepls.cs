using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weall
{
   

    public class Pickmepls : MonoBehaviour

    {
        public GameObject instructions3;
        public SelectionManager SM;
        public Transform thedest;
        public Transform playercam;
        private float throwspeed = 5f;

        private void Start()
        {
            SM = GameObject.FindObjectOfType<SelectionManager>();
            
        }
        void Update()
        {
            
            if (SM.ihavesomething == true)
            {
                SM.ihavethekey = true;
                instructions3.SetActive(true);
                transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                this.transform.rotation = this.transform.rotation;
                this.transform.position = thedest.position;
                
                this.transform.parent = GameObject.Find("TakenThings").transform;
            }
            if(SM.iseeadoor == true && SM.ihavethekey == true)
            {
                instructions3.SetActive(false);
                Debug.Log("plswork");
            }
            else if(SM.iseeadoor == false && SM.ihavethekey == true)
            {
                instructions3.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                SM.ihavethekey = false;
                Debug.Log("Throw me");
                instructions3.SetActive(false);
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<Rigidbody>().useGravity = true;
                this.transform.parent = null;
                this.transform.position = this.transform.position;
                GetComponent<Rigidbody>().AddForce(playercam.forward * throwspeed);



            }
            
            
        }

    }
}