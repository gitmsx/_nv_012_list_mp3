using System;

using System.IO;
using System.Linq;
using UnityEngine;

public class AudioMp3
{

    public string [] Listmp3Create(string PathToFolder) 

{


    
    string[] allfoldersTmp = Directory.GetFiles(PathToFolder, "*.mp3", SearchOption.AllDirectories);


    var LengthMp3 = allfoldersTmp.Length;
    var rnd2 = new Random();
    string[] allfolders_mp3 = new string[LengthMp3];


    int[] a = Enumerable.Range(0, LengthMp3).OrderBy(num => rnd2.Next()).ToArray();






            for (int i = 1; i<LengthMp3; i++)
            {
                allfolders_mp3[i] = allfoldersTmp[a[i]];
                Console.WriteLine(allfolders_mp3[i]);
            }

        return allfolders_mp3;
}

}
