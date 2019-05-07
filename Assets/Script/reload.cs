using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour
{
    public GameObject obj;
   
    public AudioSource AudioSource2;
    public bool Onwaked = true;

    // Start is called before the first frame update
    public void OnClicker()
    {
        Debug.Log("OnClicker");
        AudioSource2.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;

  
    }

    public void Onwake()
    {
        Onwaked = true;
        AudioSource2.Play();
        Time.timeScale = 0.0f;
        obj.SetActive(true);
        Debug.Log("Onwake");
    }

    public void Onsleep()
    {
        Onwaked = false;
        AudioSource2.Play();
        Time.timeScale = 1.0f;
        obj.SetActive(false);
        Debug.Log("Onsleep");
    }

    public void Quit()
    {
        Onwaked = false;
        AudioSource2.Play();
        SceneManager.LoadScene("TitleScene");
        Debug.Log("Quit");
    }
}
