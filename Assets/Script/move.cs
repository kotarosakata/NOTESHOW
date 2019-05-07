using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class move : MonoBehaviour
{
    private int movespeed;
    private GameObject _gameObject;
    private bool enter=true;

    void Start()
    {
        _gameObject = GameObject.Find("GameMusic");
        
    }
    void Update()
    {
        if (Time.timeScale==1.0f&&enter)
        {
            movespeed = _gameObject.GetComponent<GameController>().notesspeed;
            enter = false;
        }
        transform.Translate(-transform.forward*Time.deltaTime*movespeed);
    }
    

    public void startpoint(int a)
    {
        if (a ==0)
        {
            transform.position =new Vector3(-7.5f,0,224.5f);
        }else if(a ==1)
        {
            transform.position =new Vector3(-2.5f,0,224.5f);

        }else if (a == 2)
        {
            transform.position =new Vector3(2.5f,0,224.5f);
        }
        else if(a==3)
        {
            transform.position =new Vector3(7.5f,0,224.5f);

        }
        else 
        {
            transform.position = new Vector3(0,0,207.0f);
        }

        
    }

    public void Onclick()
    {
        Debug.Log("onclick");
        gameObject.SetActive(false);
    }




}
