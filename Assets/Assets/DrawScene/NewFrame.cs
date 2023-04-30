using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewFrame : MonoBehaviour
{

    LineGenerator lineGen;

    public int frameCount = 0;

    public TextMeshProUGUI FrameCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        lineGen = FindObjectOfType<LineGenerator>();
        FrameCounter.text = "" + frameCount;
    }

    IEnumerator ClearCanvas()
    {
        yield return new WaitForSeconds(0.01f);
        //asteapta ^ inainte sa se execute codul de jos

        for (int i = lineGen.linesParent.childCount - 1; i >= 0; i--)
        {
            Destroy(lineGen.linesParent.GetChild(i).gameObject);
        }

        lineGen.lineCount = 0;
        //nu mai avem linii, deci resetam lineCount
    }

    public void NewFrameClick()
    {
        ScreenshotHandler.TakeScreenshot_Static(Screen.width, Screen.height);
        //salveaza poza, apoi vrem sa stergem canvas-ul

        StartCoroutine(ClearCanvas());
        //codul de stergere e asa de rapid incat sterge liniile inainte sa se exporteze poza
        //asa ca am dat un delay la codul de stergere

        frameCount++;

        FrameCounter.text = "" + frameCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
