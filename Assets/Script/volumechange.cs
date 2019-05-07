using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumechange : MonoBehaviour
{
    private float Volume;
    private float Volume2;
    public Text Text;
    public GameObject GameObject;
    public GameObject GameObject2;
    private Vector3 _recttransform;

    private void Start()
    {
        _recttransform.x = 0;
        _recttransform.y = 0;
        _recttransform.z = 0;
    }


    public void SliderChange()
    {
        
        Volume2 = gameObject.GetComponent<Slider>().value;
        Text.text = "" + Volume2;
        GameObject.GetComponent<GameController>().Offset = Volume2 * 0.001f;
 //       Debug.Log(Volume2);
    }

    public void VolumeChange()
    {
        Volume2 = gameObject.GetComponent<Slider>().value;
        Text.text = "" + Volume2;
        GameObject.GetComponent<GameController>().notesspeed = (int)Volume2*20;
    }

    public void Covered()
    {
        Volume2 = gameObject.GetComponent<Slider>().value;
        Text.text = "" + Volume2;
        _recttransform.y = 720-56*Volume2;
        GameObject2.GetComponent<RectTransform>().localPosition = _recttransform;

    }

    public void covered2(int a)
    {
        _recttransform.y = 720-56*a;
        GameObject2.GetComponent<RectTransform>().localPosition = _recttransform;
    }
}
