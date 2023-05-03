using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class AppStart : MonoBehaviour
{

    public Texture2D cursorTexture; 
    public Vector2 cursorHotspot = new Vector2(0, 0); //hotspot = marime..?

    // Start is called before the first frame update
    void Start()
    {
        string folderPath = Application.dataPath + "/AllDrawings/";
        //Invoke("DeleteFolderContents", 1f);
        Directory.Delete(folderPath, true);
        Directory.CreateDirectory(folderPath);
    }

    /*
    private void DeleteFolderContents()
    {
        
        DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
        //sa stim unde sa ne uitam
        FileInfo[] files = directoryInfo.GetFiles();
        //facem un vector cu toate filele din folder
        foreach(FileInfo file in files)
        {
            file.Delete();
        }
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
