using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public GameObject JusticeCritical;

    public GameObject Justice;

    public GameObject Attack;

    public GameObject Miss;
    
    public GameObject Rank;
    // Start is called before the first frame update
    void Start()
    {
        JusticeCritical.GetComponent<Text>().text = "" + Data.Instance.JusticeCritical;
        Justice.GetComponent<Text>().text = "" + Data.Instance.Justice;
        Attack.GetComponent<Text>().text = "" + Data.Instance.Attack;
        Miss.GetComponent<Text>().text = "" + (Data.Instance.notetimes - (Data.Instance.JusticeCritical+Data.Instance.Justice+Data.Instance.Attack));
        Rank.GetComponent<Text>().text = "未実装";
    }
    void Update()
    {
        if (Input.touchCount>0)
        {
            SceneManager.LoadScene("GameScene");
        }
    }


    // Update is called once per frame

}
