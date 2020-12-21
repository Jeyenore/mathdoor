using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightmaterial; //The Material When It Be Selected

    [SerializeField] private Material normalmaterial; //The Material When It Be Released After Selceted

    private Transform _selection; //The Object That Will Be Selected

    private float range = 200f; //The Range That The Selection Manager Can Reach


    
    //bools for doors in which the door is open or closed

    //door1
     bool opend1;
     bool candoit;

    //door 2
     bool opend2;
     bool candoit2;

    //door3
     bool opend3;
     bool candoit3;

    //door4
     bool opend4;
     bool candoit4;

    [SerializeField]
    private Animator animationd1;
    [SerializeField]
    private Animator animationd2;
    [SerializeField]
    private Animator animationd3;
    [SerializeField] 
    private Animator animationd4;

    //UI
    public GameObject instructions;




    void Start()
    {
        
    }

    
    void Update()
    {
        if (_selection != null)
        {
            var selectionrenderer = _selection.GetComponent<Renderer>();
            selectionrenderer.material = normalmaterial;
            instructions.SetActive(true);
            _selection = null;
            
        }
        else
        {
            instructions.SetActive(false);
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            var selection = hit.transform;
            if(selection.CompareTag("Button1")) //Button1 for Door1Level1
            {
                if (Input.GetKeyDown(KeyCode.E) && opend1 == false && candoit == false)
                {
                    animationd1.SetTrigger("CloseOpen");
                    StartCoroutine(WaitD1());
                    candoit = true;
                    Debug.Log("Open");
                }
                else if (Input.GetKeyDown(KeyCode.E) && opend1 == true && candoit == true)
                {
                    animationd1.SetTrigger("CloseOpen");
                    StartCoroutine(WaitD1());
                    candoit = false;
                    Debug.Log("Close");
                }
                var selectionrenderer = selection.GetComponent<Renderer>();

                if (selectionrenderer != null)
                {
                    selectionrenderer.material = highlightmaterial;                  
                }
                _selection = selection;
            }
            else if(selection.CompareTag("Button2")) //Button2 for Door2Level1
            {
                if (Input.GetKeyDown(KeyCode.E) && opend2 == false && candoit2 == false)
                {
                    animationd2.SetTrigger("CloseOpen");
                    StartCoroutine(Waitd2());
                    candoit2 = true;
                    Debug.Log("Opend2");
                }
                else if (Input.GetKeyDown(KeyCode.E) && opend2 == true && candoit2 == true)
                {

                    StartCoroutine(Waitd2());
                    animationd2.SetTrigger("CloseOpen");
                    candoit2 = false;
                    Debug.Log("Closed2");
                }
                var selectionrenderer = selection.GetComponent<Renderer>();

                if (selectionrenderer != null)
                {
                    selectionrenderer.material = highlightmaterial;
                }
                _selection = selection;
            }
            else if (selection.CompareTag("Button3")) //Button3 for Door3Level1
            {
                if (Input.GetKeyDown(KeyCode.E) && opend3 == false && candoit3 == false)
                {
                    animationd3.SetTrigger("CloseOpen");
                    StartCoroutine(Waitd3());
                    candoit3 = true;
                    Debug.Log("Opend3");
                }
                else if (Input.GetKeyDown(KeyCode.E) && opend3 == true && candoit3 == true)
                {

                    StartCoroutine(Waitd3());
                    animationd3.SetTrigger("CloseOpen");
                    candoit3 = false;
                    Debug.Log("Closed3");
                }
                var selectionrenderer = selection.GetComponent<Renderer>();

                if (selectionrenderer != null)
                {
                    selectionrenderer.material = highlightmaterial;
                }
                _selection = selection;
            }
            else if (selection.CompareTag("Button4")) //Button4 for Door4Level1
            {
                if (Input.GetKeyDown(KeyCode.E) && opend4 == false && candoit4 == false)
                {
                    animationd4.SetTrigger("CloseOpen");
                    StartCoroutine(Waitd4());
                    candoit4 = true;
                    Debug.Log("Opend4");
                }
                else if (Input.GetKeyDown(KeyCode.E) && opend4== true && candoit4 == true)
                {

                    StartCoroutine(Waitd4());
                    animationd4.SetTrigger("CloseOpen");
                    candoit4 = false;
                    Debug.Log("Closed4");
                }
                var selectionrenderer = selection.GetComponent<Renderer>();

                if (selectionrenderer != null)
                {
                    selectionrenderer.material = highlightmaterial;
                }
                _selection = selection;
            }
        }
    }




    IEnumerator WaitD1()
    {
        
        yield return new WaitForSeconds(1.20f);
        opend1 = !opend1;

    }
    IEnumerator Waitd2()
    {
        yield return new WaitForSeconds(1.20f);
        opend2 = !opend2;
    }
    IEnumerator Waitd3()
    {
        yield return new WaitForSeconds(1.20f);
        opend3 = !opend3;
    }
    IEnumerator Waitd4()
    {
        yield return new WaitForSeconds(1.20f);
        opend4 = !opend4;
    }
}
