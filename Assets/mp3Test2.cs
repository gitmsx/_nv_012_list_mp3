using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class mp3Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    AudioClip _audioClip;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();


        LoadButton2();
        audioSource.clip = _audioClip;
        audioSource.Play();

        //    LoadButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadButton2()
    { 
    StartCoroutine(LoadMusic("D:/1/2.mp3"));
    }

    //public void LoadButton()
    //{
    //    StartCoroutine(LoadAudioClip());
    //}
    //IEnumerator LoadAudioClip()
    //{
    //  //  using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(("file:///D:/1/1.mp3"), AudioType.MPEG))
    //    using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(("file:///D:/1/2.mp3"), AudioType.MPEG))
    //    {
    //        yield return uwr.SendWebRequest();
    //        var  Musics = DownloadHandlerAudioClip.GetContent(uwr);

    //        audioSource.clip = Musics;

    //        audioSource.Play();
    //    }
    //}









    IEnumerator LoadMusic(string songPath)
    {

        Debug.Log("file:///" + songPath);
        if (System.IO.File.Exists(songPath))
        {

            
            using (var uwr = UnityWebRequestMultimedia.GetAudioClip("file:///" + songPath, AudioType.MPEG))
            {
                ((DownloadHandlerAudioClip)uwr.downloadHandler).streamAudio = true;

                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.LogError(uwr.error);
                    yield break;
                }

                DownloadHandlerAudioClip dlHandler = (DownloadHandlerAudioClip)uwr.downloadHandler;

                if (dlHandler.isDone)
                {
                    AudioClip audioClip = dlHandler.audioClip;

                    if (audioClip != null)
                    {
                        _audioClip = DownloadHandlerAudioClip.GetContent(uwr);

                        Debug.Log("Playing song using Audio Source!");

                    }
                    else
                    {
                        Debug.Log("Couldn't find a valid AudioClip :(");
                    }
                }
                else
                {
                    Debug.Log("The download process is not completely finished.");
                }
            }
        }
        else
        {
            Debug.Log("Unable to locate converted song file.");
        }
    }
}
