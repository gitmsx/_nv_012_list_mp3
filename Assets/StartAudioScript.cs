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


        Debug.Log(ListAllMp3);
        Debug.Log(ListAllMp3.Length);

        StartCoroutine(GetAudioClip(ListAllMp3[i]));

        Debug.Log("2 nd ");
        for (int i = 0; i < ListAllMp3.Length; i++)
        {
            Debug.Log(ListAllMp3[i]);

            //audioSource.Stop();
            //audioSource.clip = 
            //audioSource.Play();
        //    StartCoroutine(CclipStart());

        }

    }


    IEnumerator CclipStart()
    {


        audioSource.clip = myClip2;
        Debug.Log("audioSource.clip.length");
        Debug.Log(audioSource.clip.length);


     //   audioSource.Play();
        yield return new WaitForSeconds(12);
    }

    IEnumerator GetAudioClip(string Pasd)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("D:\\1\\2.mp3", AudioType.MPEG))
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
                Debug.Log("Read Ok");

            }
        }
    }
}



