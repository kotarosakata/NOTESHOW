using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteEditor.DTO;
using System.IO;
using NoteEditor.Model;
using NoteEditor.Presenter;
using UnityEngine.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    public string JsonFilePath;

    public string TimingfilePath;
    // Start is called before the first frame update
    void Start()
    {
        var json = File.ReadAllText(JsonFilePath, System.Text.Encoding.UTF8);
        var editData = JsonUtility.FromJson<MusicDTO.EditData>(json);
        Debug.Log("okok");
        for (int i = 0; i < 400; i++)
        {
            if (editData.notes[i].LPB == 4)
            {
                editData.notes[i].num = editData.notes[i].num * 2;
            }
            WriteCSV(editData.notes[i].num*0.075f+2.42f+","+editData.notes[i].block);
        }
        
    }

    // Update is called once per frame

    public void WriteCSV(string txt){
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo (Application.dataPath +"/"+ TimingfilePath + ".txt");
        streamWriter = fileInfo.AppendText ();
        streamWriter.WriteLine (txt);
        streamWriter.Flush();
        streamWriter.Close ();
    }
}
