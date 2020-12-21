using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace weall
{


    public class SelectionManager : MonoBehaviour

    {

        [SerializeField] private Material highlightmaterial;
        [SerializeField] private Material normalmaterial;
        Material originalmaterial;
        public bool dooropen = false;
        public Transform door;
        private Transform _selection;
        public Animator anim;
        private float range = 200f;
        bool candoit = false;
        public GameObject Instructions1;
        public GameObject Instructions2;
        public GameObject Instructions4;
        public GameObject Instructions5;
        [HideInInspector] public bool pickmeup;
        public GameObject canbehold;
        public Transform pickplace;
        public Rigidbody rb;

        [HideInInspector] public MouseLookCC mouselook;
        [HideInInspector] public bool grabme;
        [HideInInspector] public bool ihavesomething;
        [HideInInspector] public bool canbepcik;
        [HideInInspector] public bool throwme;
        [HideInInspector] public bool ihavethekey;
        [HideInInspector] public bool iseeadoor;
        [HideInInspector] public bool ilostthekey;
        [HideInInspector] public bool examine;
        [HideInInspector] public MoveCC movement;
        public Animator anim1;
        //bools for door's animation
        [HideInInspector] public bool dooropen1;






        private void Start()
        {
            mouselook = GameObject.FindObjectOfType<MouseLookCC>();
            movement = GameObject.FindObjectOfType<MoveCC>();
            
            GetComponent<Pickmepls>();

        }
        void Update()
        {

            if (_selection != null)
            {
                var selectionrenderer = _selection.GetComponent<Renderer>();
                selectionrenderer.material = normalmaterial;

                _selection = null;
                Instructions1.SetActive(false);
                Instructions2.SetActive(false);
                Instructions5.SetActive(false);
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range) && movement.iusecal == false)
            {

                var selection = hit.transform;
                Instructions4.SetActive(false);
                if (selection.CompareTag("Door"))
                {
                    iseeadoor = true;
                    if (Input.GetKeyDown(KeyCode.E) && dooropen == false && candoit == false)
                    {
                        Instructions4.SetActive(false);
                        anim.SetTrigger("CloseOpen2");
                        StartCoroutine(timeforopen());
                        dooropen = true;
                        

                    }
                    else if (Input.GetKeyDown(KeyCode.E) && dooropen == true && candoit == true)
                    {
                        Instructions4.SetActive(false);
                         anim.SetTrigger("CloseOpen2");
                        StartCoroutine(timeforopen());
                        dooropen = false;
                       
                        

                    }

                    var selectionrenderer = selection.GetComponent<Renderer>();

                    if (selectionrenderer != null)
                    {


                        selectionrenderer.material = highlightmaterial;
                        Instructions1.SetActive(true);
                        Instructions4.SetActive(false);

                    }
                    else
                    {

                        Instructions1.SetActive(false);
                        Instructions4.SetActive(true);
                    }
                    _selection = selection;
                }
                else if (selection.CompareTag("Untagged"))
                {
                    iseeadoor = false;
                }
                else if (selection.CompareTag("Button") )
                {
                    if (Input.GetKeyDown(KeyCode.E) && dooropen1 == false && candoit == false)
                    {

                        Instructions4.SetActive(false);
                        anim1.SetTrigger("CloseOpen1");
                        StartCoroutine(timeforopen());
                        dooropen1 = true;
                        

                    }

                    else if (selection.CompareTag("Button") )
                    {
                        if (Input.GetKeyDown(KeyCode.E) && dooropen1 == true && candoit == true )
                        {

                            Instructions4.SetActive(false);                    
                            anim1.SetTrigger("CloseOpen1");
                            StartCoroutine(timeforopen());
                            dooropen1 = false;
                            

                        }


                        var selectionrenderer = selection.GetComponent<Renderer>();
                        if (selectionrenderer != null)
                        {
                            Instructions1.SetActive(true);
                            selectionrenderer.material = highlightmaterial;

                        }
                        else
                        {
                            selectionrenderer.material = normalmaterial;
                        }
                        _selection = selection;
                    }


                    else if (selection.CompareTag("pickable"))
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {

                            ihavesomething = true;
                        }


                        var selectionrenderer = selection.GetComponent<Renderer>();
                        if (selectionrenderer != null)
                        {
                            Instructions1.SetActive(true);
                            selectionrenderer.material = highlightmaterial;

                        }
                        else
                        {
                            selectionrenderer.material = normalmaterial;
                        }
                        _selection = selection;
                    }
                    else if (selection.CompareTag("Examine"))
                    {

                        if (Input.GetKeyDown(KeyCode.E))
                        {

                            Instructions5.SetActive(true);
                            examine = true;
                            Debug.Log("Examine");
                        }


                        var selectionrenderer = selection.GetComponent<Renderer>();
                        if (selectionrenderer != null)
                        {
                            Instructions1.SetActive(true);
                            selectionrenderer.material = highlightmaterial;

                        }
                        else
                        {

                            selectionrenderer.material = normalmaterial;

                        }
                        _selection = selection;
                    }

                }
                else
                {

                    grabme = false;
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ihavesomething = false;
                }
                else if (Input.GetMouseButton(1))
                {
                    examine = false;
                    Instructions5.SetActive(false);
                }

            }
             IEnumerator timeforopen()
            {

                Debug.Log("Worked!");

                yield return new WaitForSeconds(1f);

                candoit = !candoit;


            }
             
        }
    }
}
