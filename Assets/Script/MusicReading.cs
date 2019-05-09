using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteEditor.DTO;
using System.IO;
using NoteEditor.Model;
using NoteEditor.Presenter;
using UnityEngine.Serialization;

public class MusicReading : MonoBehaviour
{
    public string filePath;
    public string timingfilePath;
    private int n = 0;
    private int[] notestiming = new int[1000];
    private int[] notesposition = new int[1000];
    private int[] notestiming2 = new int[1000];
    private ObjectPool obj;
    public GameObject Prefab2;
    public int Notes;
    private int i;
    private GameObject _gameobject;
    void Start(){
    
        var json = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
        var editData = JsonUtility.FromJson<MusicDTO.EditData>(json);
        var notePresenter = EditNotesPresenter.Instance;
        Debug.Log(n);
        for (n = 0;n<=439; n++)
        {
            if (editData.notes[n].LPB==8)
            {
                notestiming[n] = editData.notes[n].num /editData.notes[n].LPB;
                notestiming2[n] = editData.notes[n].num %= editData.notes[n].LPB;
                
            }
            else
            {
                notestiming[n] = editData.notes[n].num /editData.notes[n].LPB;
                notestiming2[n] = (editData.notes[n].num %= editData.notes[n].LPB) * 2;
            }
            notesposition[n] = editData.notes[n].block;

        }
        obj = GetComponent<ObjectPool>();
        obj.CreatePool(Prefab2,Notes);
        i = 0;
        Debug.Log(n);
    }

    private void Update()
    {
        for (int j = 0; j <= 4; j++)
        {
            if ( Music.IsJustChangedAt(notestiming[i],0,notestiming2[i]) )
            {
                _gameobject = obj.GetObject();
                _gameobject.GetComponent<move>().startpoint(notesposition[i]);
                Debug.Log(Time.time+","+i);
                WriteCSV(Time.time+","+notesposition);
                i++;
                
            }
        }
        
    }
    
    public void WriteCSV(string txt){
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo (Application.dataPath +"/"+ timingfilePath + ".csv");
        streamWriter = fileInfo.AppendText ();
        streamWriter.WriteLine (txt);
        streamWriter.Flush();
        streamWriter.Close ();
    }
}