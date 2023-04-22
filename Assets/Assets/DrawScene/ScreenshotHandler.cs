using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{

    private static ScreenshotHandler instance;

    private Camera CanvasCam;
    private bool takeScreenshotOnNextFrame;

    int frameCount = 0;
    
    void Awake()
    {
        instance = this;
        CanvasCam = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            string folderPath = Application.dataPath + "/AllDrawings/";

            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = CanvasCam.targetTexture;

            int leftOffset = 260;
            //^ nu vrem sa se vada HUD-ul in imaginea salvata, o sa taiem atatia pixeli din dreapta

            Texture2D renderResult = new Texture2D(renderTexture.width - leftOffset, renderTexture.height, TextureFormat.ARGB32, false);
            
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            frameCount++;

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.Directory.CreateDirectory(folderPath);
            System.IO.File.WriteAllBytes(folderPath + "/Drawing" + frameCount + ".png", byteArray);
            Debug.Log("Saved CameraScreenshot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            CanvasCam.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width, int height)
    {
        CanvasCam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }

}
