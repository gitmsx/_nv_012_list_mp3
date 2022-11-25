using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class StartAudioScript : MonoBehaviour
{

    AudioSource audioSource;
    //  int CurrentClip = 0;
    string[] ListAllMp3;
    AudioClip myClip2;


    // float TimeToChangeMp3 = 7;
    //    float TimeHasLongTime = 0;



    void Start()
    {


        AudioSource audioSource = GetComponent<AudioSource>();
        AudioMp3 audioMp3 = new AudioMp3();
        string PathToFolderMp3 = "I:\\data1\\mp3.eng\\HarryPotter";
        ListAllMp3 = audioMp3.ListMp3(PathToFolderMp3);





      //  Debug.Log(" Array ListAllMp3.Length = " + ListAllMp3.Length.ToString());

        StartCoroutine(GetAudioClip(ListAllMp3[3]));




        AudioSource audioSource7 = GetComponent<AudioSource>(); ;
        audioSource7.clip = myClip2;
        Debug.Log("audioSource.clip.length = " + audioSource7.clip.length.ToString());
        Debug.Log("audioSource.clip2 length = " + myClip2.length.ToString());
        audioSource7.Play();


        //for (int i = 0; i < ListAllMp3.Length; i++)
        //{
        //    StartCoroutine(CclipStart());
        //}

    }


    IEnumerator CclipStart()
    {


        audioSource.clip = myClip2;
        Debug.Log("audioSource.clip.length = " + audioSource.clip.length.ToString());



        audioSource.Play();
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
               // AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                myClip2 = DownloadHandlerAudioClip.GetContent(www);
                Debug.Log("Read Ok");

            }
        }
    }
}



