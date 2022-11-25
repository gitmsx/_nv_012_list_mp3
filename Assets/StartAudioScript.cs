using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartAudioScript : MonoBehaviour
{

    AudioSource audioSource;
    int CurrentClip = 0;
    string[] ListAllMp3;

    void Start()
    {


        AudioSource audioSource = GetComponent<AudioSource>();



        AudioMp3 audioMp3 = new AudioMp3();
        string PathToFolderMp3 = "I:\\data1\\mp3.eng\\HarryPotter";
        ListAllMp3 = audioMp3.ListMp3(PathToFolderMp3);
        
        
        StartCoroutine(LoadSongCoroutine());


    }


    IEnumerator  LoadSongCoroutine()
    {
        audioSource.clip.set( );



        
           var  filePath = UnityWebRequest.EscapeURL(ListAllMp3[CurrentClip]);

            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file:///" + filePath, AudioType.OGGVORBIS))
            {
                if (www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                }
            }
        
            my


        CurrentClip++;
        yield return new WaitForSeconds( myClip.le);
    }

  
}
