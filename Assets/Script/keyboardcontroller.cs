using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class keyboardcontroller : MonoBehaviour
{

    public GameObject inputText;
    public GameObject GameObject;
    private TouchScreenKeyboard keyboard;
    public int named;
    private int inputnumber;
    private bool Started = false;
    public string textToEdit = "textfield";
    public GameObject GameObject2;
    private volumechange Volumechange;

    private void Start()
    {
        Volumechange = GameObject2.GetComponent<volumechange>();

    }



    public void OnClick()
    {
        this.keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
        Debug.Log("動いてる");
        Started = true;
    }
        
    
    void Update()
    {
        if (Started)
        {
            if (this.keyboard.done)
            {
                inputnumber = int.Parse(this.keyboard.text);
                if (named==1)
                {
                    if (inputnumber>=-200&&inputnumber<=200)
                    {
                        inputText.GetComponent<Text>().text = this.keyboard.text;
                        GameObject.GetComponent<GameController>().Offset = inputnumber * 0.001f;
                        Started = false;
                    }
                }
                else if (named==2)
                {
                    if (inputnumber>=1&&inputnumber<=9)
                    {
                        inputText.GetComponent<Text>().text = this.keyboard.text;
                        GameObject.GetComponent<GameController>().notesspeed = inputnumber*20;
                        Started = false;
                    }
                }else if (named == 3)
                {
                    if (inputnumber>=0&&inputnumber<=10)
                    {
                        inputText.GetComponent<Text>().text = this.keyboard.text;
                        Volumechange.covered2(inputnumber);
                        Started = false;
                    }
                }

            }
        }
        
    }
}
