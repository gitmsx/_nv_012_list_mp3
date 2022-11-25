using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class StartAudioScript : MonoBehaviour
{

    AudioClip _audioClip;
    AudioSource audioSource;
    int CurrentClip = 0;

    DateTime timeStart;
    DateTime timeEnd;



    string[] ListAllMp3;
    


     float TimeToChangeMp3 = 7;
     float TimeHasLongTime = 0;

    [SerializeField] AudioClip flySound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioMp3 audioMp3 = new AudioMp3();
        string PathToFolderMp3 = "I:\\data1\\mp3.eng\\HarryPotter";
        ListAllMp3 = audioMp3.ListMp3(PathToFolderMp3);



        StartCoroutine(LoadAudioClip(ListAllMp3[3]));

        //StartCoroutine(ListPlay());




        // ListAllMp3.Length
        

        // float TimeToChangeMp3 = 7;
        //    float TimeHasLongTime = 0;
    }



    //IEnumerator  ListPlay()
    //{
    //    while (true) 
    //    {
    //        yield return new WaitForSeconds(3);

    //        StartCoroutine(LoadAudioClip(ListAllMp3[i]));
    //    }

    //}




    IEnumerator LoadAudioClip(string PtsPath)
    {

        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip((PtsPath), AudioType.MPEG))
        {
            yield return uwr.SendWebRequest();
            _audioClip = DownloadHandlerAudioClip.GetContent(uwr);
            audioSource.clip = _audioClip;
            audioSource.Play();
            timeStart = DateTime.Now;
            timeEnd = timeStart.AddSeconds ( _audioClip.length);

            Debug.Log(timeStart);
            Debug.Log(timeEnd);

            //   StartCoroutine(AudioClip());
        }
    }


}



