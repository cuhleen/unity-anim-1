using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Export : MonoBehaviour
{

    string path = @"E:\003 Unity\Projects\animat 1\% GifCompiler\% GifCompiler\bin\Debug\net6.0/% GifCompiler.exe";

    public void OpenGifCompiler()
    {
        Process.Start(path);
    }
}
