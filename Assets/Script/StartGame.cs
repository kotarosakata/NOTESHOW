using  System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioSource _AudioSource2;


    private void Start()
    {
                Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Input.touchCount>0)
        {
            StartCoroutine(_coroutine());
        }
    }

    IEnumerator _coroutine()
    {

        _AudioSource2.Stop();
        _audioSource.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }


}
