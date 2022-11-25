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

    [SerializeField] AudioClip flySound;

    void Start()
    {

        
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioMp3 audioMp3 = new AudioMp3();
        string PathToFolderMp3 = "I:\\data1\\mp3.eng\\HarryPotter";
        ListAllMp3 = audioMp3.ListMp3(PathToFolderMp3);
        Debug.Log("1. audioSource.clip.length = " + audioSource.clip.length.ToString());
        audioSource.PlayOneShot(flySound);
       


        StartCoroutine(GetAudioClip(ListAllMp3[3]));
        audioSource.clip = myClip2;
        Debug.Log("2. audioSource.clip.length = " + audioSource.clip.length.ToString());


        audioSource.Play();


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
                Debug.Log(DownloadHandlerAudioClip.GetContent(www));
                Debug.Log("Read Ok");

            }
        }
    }
}



