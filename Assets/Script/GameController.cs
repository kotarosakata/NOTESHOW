using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Linq;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    
    private AudioSource _audioSource;
    public GameObject prefab;
    private ObjectPool objectpool;
    private float Starttime;
    public GameObject[] notes;
    public float[] _timing;
    public int[] _lineNum;
    public int CobBotimes = 0;
    private bool Stop,start=true;
    public string FilePass;
    int i = 0,a=0;
    public  int notesspeed;
    public float Offset;
    private bool isstart = false;
    public TextMesh Finaltext;
    public GameObject check;
    private bool startstart=false;
    private bool isplaying=false;


    public void gameend()
    {
        Debug.Log("gameend");
        if (!isstart)
        {
            if (Data.Instance.Miss==0&&Data.Instance.Attack==0)
            {
                Finaltext.text = "ALL JUSTICE";
            }
            if (Data.Instance.Miss==0)
            {
                Finaltext.text = "FULL COMBO";
            }
            else
            {
                Finaltext.text = "CLEAR";
            }

            isplaying = true;
            isstart = true;
        }
        SceneManager.LoadScene("Result");

      //  gameend2();

    }

    IEnumerator gameend2()
    {
        Debug.Log("gameend2");

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Result");

    }
    
    


    void Start()
    {
        Time.timeScale = 0.0f;
        
        objectpool = GetComponent<ObjectPool>();
        objectpool.CreatePool(prefab,440);
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource> ();
        _timing = new float[1024];
        _lineNum = new int[1024];


        LoadCSV ();

    }



    private void Update()
    {

        
        if (Time.timeScale==1.0f&&start)
        {
            Debug.Log("startmusic");
            StartCoroutine(StartMusic());
            start = false;
        }

        if (Time.timeSinceLevelLoad>=69)
        {
//            Debug.Log("第一関門突破");
            if (!_audioSource.isPlaying) {
  //              Debug.Log("第二関門突破");
                if (!check.GetComponent<reload>().Onwaked)
                {
    //                Debug.Log("第三関門突破");
                    gameend();
                }
            }
        }
        


        

//        Debug.Log(Math.Abs(Time.time - _timing[i]));
        if (Math.Abs(Time.timeSinceLevelLoad-Starttime - _timing[i]) < 0.05)
        {
            
            prefab = objectpool.GetObject();
            prefab.GetComponent<move>().startpoint(_lineNum[i]);
            Data.Instance.notetimes += 1;

//            Debug.Log(iTime.timeSincelevelLoad);
            i++;
            for (int j = 0; j < 3; j++)
            {
                if (_timing[i-1] == _timing[i])
                {
                    prefab = objectpool.GetObject();
                    prefab.GetComponent<move>().startpoint(_lineNum[i]);
 //                   Debug.Log(i);
                    Data.Instance.notetimes += 1;

                    i++;
                }
            }
        }

        if (Time.timeScale==0.0f)
        {
            _audioSource.Pause();
            Stop = true;
        }
        else if (Stop)
        {
            _audioSource.UnPause();
            Stop = false;
        }

    }


    IEnumerator StartMusic()
    {
        Starttime = Time.timeSinceLevelLoad;
        yield return new WaitForSeconds((242f/notesspeed)+Offset);
        _audioSource.Play ();
//       Debug.Log(Offset);
        
    }
    void LoadCSV(){

            TextAsset csv = Resources.Load (FilePass) as TextAsset;

            StringReader reader = new StringReader(csv.text);

            int i = 0;
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);
                _lineNum[i] = int.Parse(values[1]);
            }

            i++;
        }
    }
    
    
}
