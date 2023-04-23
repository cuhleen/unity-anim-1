using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class AppStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string folderPath = Application.dataPath + "/AllDrawings/";
        
    }

    private void DeleteFolderContents(string path)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        //sa stim unde sa ne uitam
        FileInfo[] files = directoryInfo.GetFiles();
        //facem un vector cu toate filele din folder
        foreach(FileInfo file in files)
        {
            file.Delete();
        }

        DirectoryInfo[] directories = directoryInfo.GetDirectories();
        foreach (DirectoryInfo directory in directories)
        {
            directory.Delete(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
