using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartAudioScript : MonoBehaviour
{

    AudioSource audioSource;
    int CurrentClip = 0;
    string[] ListAllMp3;
    AudioClip myClip2;


    float TimeToChangeMp3 = 7;
    float TimeHasLongTime = 0;



    void Start()
    {


        AudioSource audioSource = GetComponent<AudioSource>();
        AudioMp3 audioMp3 = new AudioMp3();
        string PathToFolderMp3 = "I:\\data1\\mp3.eng\\HarryPotter";
        ListAllMp3 = audioMp3.ListMp3(PathToFolderMp3);
        
        


        StartCoroutine(GetAudioClip());

        audioSource.Stop();
        audioSource.clip = myClip2;
        audioSource.Play();


    }

    IEnumerator GetAudioClip()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(@"I:\data1\mp3.eng\HarryPotter\Harry Potter Fry\Book 1 - Harry Potter and the Philosopher's Stone (1997)\01 - The Boy Who Lived.mp3", AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                myClip2 = DownloadHandlerAudioClip.GetContent(www);

            }
        }
    }
}

  

