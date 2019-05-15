using System;
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

    public GameObject Comment;

    private int points;
    // Start is called before the first frame update
    void Start()
    {
        JusticeCritical.GetComponent<Text>().text = "" + Data.Instance.JusticeCritical;
        Justice.GetComponent<Text>().text = "" + Data.Instance.Justice;
        Attack.GetComponent<Text>().text = "" + Data.Instance.Attack;
        Miss.GetComponent<Text>().text = "" + (Data.Instance.notetimes - (Data.Instance.JusticeCritical+Data.Instance.Justice+Data.Instance.Attack));
        points = (Data.Instance.JusticeCritical * 100 + Data.Instance.Justice * 50 + Data.Instance.Attack * 10)/Data.Instance.notetimes;
        if (points==100)
        {
            Rank.GetComponent<Text>().text = "S";
            Comment.GetComponent<Text>().text = "人間卒業おめでとう!";
        }else if (points>=98)
        {
            Rank.GetComponent<Text>().text = "A++";
            Comment.GetComponent<Text>().text = "いい精度だ。感動的だな。"+Environment.NewLine+"だが無意味だ。";
        }else if (points>=95)
        {
            Rank.GetComponent<Text>().text = "A+";
            Comment.GetComponent<Text>().text = "まだまだだね";
        }else if (points>=90)
        {
            Rank.GetComponent<Text>().text = "A";
            Comment.GetComponent<Text>().text = "うわっ…私の精度、低すぎ…？";
        }else if (points>=85)
        {
            Rank.GetComponent<Text>().text = "B++";
            Comment.GetComponent<Text>().text = "そんな精度で大丈夫か？";
        }else if (points>=80)
        {
            Rank.GetComponent<Text>().text = "B+";
            Comment.GetComponent<Text>().text = "低精度はステータスだ！希少価値だ！";
        }else if (points>=75)
        {
            Rank.GetComponent<Text>().text = "B";
            Comment.GetComponent<Text>().text = "まったく、低精度は最高だぜ!!";
        }else if (points>=70)
        {
            Rank.GetComponent<Text>().text = "C++";
            Comment.GetComponent<Text>().text = "この幻想郷では精度に囚われてはいけないのですね！";
        }else if (points>=65)
        {
            Rank.GetComponent<Text>().text = "C+";
            Comment.GetComponent<Text>().text = "精度なんて飾りです。"+Environment.NewLine+"偉い人にはそれが分からんのです！";

        }else if (points>=60)
        {
            Rank.GetComponent<Text>().text = "C";
            Comment.GetComponent<Text>().text = "精度だけで…一体何が守れるって言うんだ！！";

        }else if (points>=55)
        {
            Rank.GetComponent<Text>().text = "D";
            Comment.GetComponent<Text>().text = "精度では消せんのです・・・恨みも、後悔も・・・";


        }else if (points>=50)
        {
            Rank.GetComponent<Text>().text = "E";
            Comment.GetComponent<Text>().text = "低精度を気に病むことはない。ただ認めて次の糧にすればいい。それが大人の特権だ";


        }else
        {
            Rank.GetComponent<Text>().text = "F";
            Comment.GetComponent<Text>().text = "まず決める。そしてやり通す。"+Environment.NewLine+"それが何かを成す時の唯一の方法ですわ";

        }
        

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
