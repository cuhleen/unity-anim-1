using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{

    private static ScreenshotHandler instance;

    private Camera CanvasCam;
    //am fi putut face si cu o camera separata, dar, cu cunostintele pe care le am acum, e mai usor doar sa taiem HUD-ul din poza
    //poate o sa aflu o metoda mai buna cu o alta camera
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
            //poate la un moment dat o sa vreau sa fac incat fiecare animatie sa fie in folderul propriu
            //momentan toate desenele se pun intr-un folder

            //am facut ca la fiecare pornire de aplicatie sa se stearga continutul folderului
            //vezi script-ul

            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = CanvasCam.targetTexture;

            int leftOffset = 260;
            //^ nu vrem sa se vada HUD-ul in imaginea salvata, o sa taiem atatia pixeli din dreapta

            Texture2D renderResult = new Texture2D(renderTexture.width - leftOffset, renderTexture.height, TextureFormat.ARGB32, false);
            
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            frameCount++;
            //daca user-ul apasa pe butonul de poza inseamna ca desenul curent e gata
            //canvasul se elibereaza
            //trecem la frame-ul urmator din animatie

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.Directory.CreateDirectory(folderPath);
            if(frameCount < 10)
                System.IO.File.WriteAllBytes(folderPath + "/Drawing00" + frameCount + ".png", byteArray);
            else if(frameCount < 100)
                System.IO.File.WriteAllBytes(folderPath + "/Drawing0" + frameCount + ".png", byteArray);
            else
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

    //^ functia asta este o "poarta de intrare" (vezi "public static void")
    //adica putem apela asta din alte script-uri

}
