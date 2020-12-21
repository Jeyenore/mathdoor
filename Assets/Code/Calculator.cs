using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public float result;
    private float input;
    private float input2;
    private string operations;
    public Text inputtext;
    public Text operationsText;
    string nothing = "";

    void Start()
    {
        
    }
    
    public void ClickedNumber(int val)
    {
        Debug.Log(val);

        inputtext.text = val.ToString();
        if (input == 0)
        {
            input = val;
        }
        else
        {
            input2 = val;
        }

    }
    public void ClickedOperations(string val)
    {
        Debug.Log(val);
        operations = val;
        operationsText.text = val.ToString();

    }
    public void ClickedEqual(string val)
    {

        Debug.Log(val);
        if (input != 0 && input2 != 0 && !string.IsNullOrEmpty(operations))
        {

            switch (operations)
            {
                case "+":
                    result = input + input2;
                    break;
                case "-":
                    result = input - input2;
                    break;
                case "*":
                    result = input * input2;
                    break;
                case "/":
                    result = input / input2;
                    break;



            }
            inputtext.text = result.ToString();
            clearinput();
        }
    }
    public void ClickedPeriod(string val)
    {
        Debug.Log(val);
    }
    public void clearinput()
    {
        input = 0;
        input2 = 0;
        operationsText.text = nothing;
    }

}