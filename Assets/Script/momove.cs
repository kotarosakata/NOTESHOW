using System;
using System.Collections;
using UnityEngine;
using System.IO;
using System.Net.Mime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Data  
{
    public static Data Instance = new Data();

    public int JusticeCritical = 0;
    public int Justice = 0;
    public int Attack = 0;
    public int Miss = 0;
    public int notetimes = 0;

}
public class momove : MonoBehaviour
{
    public float touchtiming;
    private float misstiming,notespeedoffset;
    private GameObject _gameObject;
    private GameController _gameController;
    private float[] LineNotes = new float[400];
    public int Notespossition;
    private int n = 0, a = 0;
    public TextMesh texttext;
    public string Timingfile;
    private float[] NotesTime = new float[440];
    private int[] _line = new int [440];
    private bool[] ComboNotes = new Boolean[440];
    private int Combotime=0;
    private TextAsset csv;
    public TextMesh combotext;
    public Material Mat1;
    public Material Mat2;
    public AudioSource audio;
    private Renderer _renderer;
    private Renderer _renderer1;
    private bool start =true;

//    private Material Mat3;

    private void Start()
    {
        Data.Instance.JusticeCritical = 0;
        Data.Instance.Justice = 0;
        Data.Instance.Attack = 0;
        Data.Instance.Miss = 0;
        _renderer1 = gameObject.GetComponent<Renderer>();
        _renderer = gameObject.GetComponent<Renderer>();
        _gameObject= GameObject.Find("GameMusic");
        _gameController = _gameObject.GetComponent<GameController>();
        LoadCSV();
        for (int i = 0; i < 440; i++)
        {

            if (_line[i]==Notespossition)
            {
                LineNotes[n]=NotesTime[i];
                n++;
            }

            ComboNotes[i] = false;
        }

    }



    public void OnClick()
    {
        touchtiming = Time.timeSinceLevelLoad;
    //    Debug.Log(touchtiming);
        StartCoroutine(colorchenge());
        audio.Play();


 
          
        if (start)
        {
            notespeedoffset = (242.0f / _gameController.notesspeed)-2.42f;
            start = false;
        }

  //      Debug.Log("touch");
        for (int i = a;i<=(n-1); i++)
        {
            if (Math.Abs(LineNotes[i]-touchtiming+notespeedoffset)<0.04)
            {
                a=++i;
                Data.Instance.JusticeCritical += 1;
                ComboNotes[i] = true;
                texttext.color = Color.yellow;
                texttext.text = "Justice"+ Environment.NewLine+" Critical";
                    _gameController.CobBotimes += 1;
                    combotext.text = ""+_gameController.CobBotimes;

                
            }
            else if (Math.Abs(LineNotes[i]-touchtiming+notespeedoffset)<0.06)
            {
                a=++i;
                Data.Instance.Justice += 1;
                ComboNotes[i] = true;
                texttext.color = Color.yellow;
                texttext.text = "Justice ";
                    _gameController.CobBotimes += 1;
                    combotext.text = ""+_gameController.CobBotimes;


                

            }else if (Math.Abs(LineNotes[i] - touchtiming+notespeedoffset) < 0.1)
            {
                a=++i;
                Data.Instance.Attack += 1;
                ComboNotes[i] = true;
                texttext.color = Color.green;
                texttext.text = "Attack";
                    _gameController.CobBotimes += 1;
                    combotext.text = ""+_gameController.CobBotimes;

                
            }else if (Math.Abs(LineNotes[i] - touchtiming+notespeedoffset)<0.2)
            {
                a=++i;
                Data.Instance.Miss += 1;
                ComboNotes[i] = true;
                texttext.color = Color.cyan;        
                texttext.text = "MISS";
                _gameController.CobBotimes = 0;
//                debugext.text = "miss" + _gameController.CobBotimes;
                combotext.text = "";
                
            }

            
        }
        
        StartCoroutine(Coroitine());

    }

    IEnumerator Coroutine2()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Result");
    }

    IEnumerator colorchenge()
    {
        _renderer.material = Mat1;
        yield return new WaitForSeconds(0.1f);
        _renderer.material = Mat2;

    }

    private void OnTriggerEnter(Collider other)
    {
        misstiming = Time.timeSinceLevelLoad;
        
        

        if (other.CompareTag("Player"))
        {
            for (int i = a; i < (n-1); i++)
            {
                if (Math.Abs(LineNotes[i]-misstiming)<5)
                {
                    if (!ComboNotes[i])
                    {
                        Data.Instance.Miss += 1;
                        _gameController.CobBotimes = 0;
                        combotext.text = "";

                        ComboNotes[i] = true;
                        StartCoroutine(Coroitine());
                        other.gameObject.SetActive(false);
                    }
                    
                }
                
            }
           
        }
        

        
    }

    void LoadCSV(){

        csv = Resources.Load (Timingfile) as TextAsset;

        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                NotesTime[i] = float.Parse(values[0]);
                _line[i] = int.Parse(values[1]);
            }

            i++;
        }
    }

    IEnumerator Coroitine()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return null;
        }

        texttext.text = "";
    }
//    public void WriteCSV(string txt){
//        StreamWriter streamWriter;
//        FileInfo fileInfo;
//        fileInfo = new FileInfo (Application.dataPath +"/"+ Timingfile + ".txt");
//      streamWriter = fileInfo.AppendText ();
//      streamWriter.WriteLine (txt);
//       streamWriter.Flush();
//        streamWriter.Close ();
//    }
}




