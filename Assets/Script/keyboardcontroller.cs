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

    private int Startoffset=0;
    private int Startspeed=0;
    private int Startcover=0;
    
    private void Start()
    {
        Volumechange = GameObject2.GetComponent<volumechange>();
        Startoffset = PlayerPrefs.GetInt("Offset");
        Startspeed = PlayerPrefs.GetInt("Speed");
        Startcover = PlayerPrefs.GetInt("Cover");
        if (named==1)
        {
            inputText.GetComponent<Text>().text = ""+Startoffset;
            GameObject2.GetComponent<Slider>().value = Startoffset;

            GameObject.GetComponent<GameController>().Offset = Startoffset * 0.001f;
        }
        else if (named==2)
        {
            inputText.GetComponent<Text>().text = ""+Startspeed;
            GameObject2.GetComponent<Slider>().value = Startspeed;

            GameObject.GetComponent<GameController>().notesspeed = Startspeed*20;
        }else if (named == 3)
        {
            inputText.GetComponent<Text>().text = ""+Startcover;
            Volumechange.covered2(Startcover);
            GameObject2.GetComponent<Slider>().value = Startcover;
            
        }

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
                        PlayerPrefs.SetInt("Offset",inputnumber);
                        inputText.GetComponent<Text>().text = this.keyboard.text;
                        GameObject.GetComponent<GameController>().Offset = inputnumber * 0.001f;
                        GameObject2.GetComponent<Slider>().value = inputnumber;
                        Started = false;
                    }
                }
                else if (named==2)
                {
                    if (inputnumber>=1&&inputnumber<=9)
                    {
                        PlayerPrefs.SetInt("Speed",inputnumber);
                        inputText.GetComponent<Text>().text = this.keyboard.text;
                        GameObject.GetComponent<GameController>().notesspeed = inputnumber*20;
                        GameObject2.GetComponent<Slider>().value = inputnumber;

                        Started = false;
                    }
                }else if (named == 3)
                {
                    if (inputnumber>=0&&inputnumber<=10)
                    {
                        PlayerPrefs.SetInt("Cover",inputnumber);
                        inputText.GetComponent<Text>().text = this.keyboard.text;
                        Volumechange.covered2(inputnumber);
                        GameObject2.GetComponent<Slider>().value = inputnumber;

                        Started = false;
                    }
                }

            }
        }
        
    }
}
