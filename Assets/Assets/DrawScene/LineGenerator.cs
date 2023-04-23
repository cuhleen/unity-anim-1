//epic
//codul asta are cam multe chestii in el
//daca chiar incercam, poate am putea sa facem coduri separate pentru mai multe functii

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{

    public GameObject linePrefab;

    Line activeLine;

    int lineCount = 0;

    private ChangeBrush changeBrush;
    private ChangeEraser changeEraser;

    private WidthSliderScript wSlider;

    public Color BrushCol = new Color32(0, 0, 0, 1);
    Color bgCol = new Color32(255, 255, 255, 1);

    private Transform linesParent;
    // grupeaza toate liniile intr-un "folder"

    private void UpdateLine()
    {
        if (activeLine != null)
        {
            activeLine.SetLineWidth(wSlider.width);
        }
    }

    private void Start()
    {
        changeBrush = FindAnyObjectByType<ChangeBrush>();
        changeEraser = FindAnyObjectByType<ChangeEraser>();
        wSlider = FindAnyObjectByType<WidthSliderScript>();
        linesParent = new GameObject("LinesParent").transform;
    }

    IEnumerator ClearCanvas()
    {
        yield return new WaitForSeconds(0.01f);
        //asteapta ^ inainte sa se execute codul de jos

        for (int i = linesParent.childCount - 1; i >= 0; i--)
        {
            Destroy(linesParent.GetChild(i).gameObject);
        }

        lineCount = 0;
        //nu mai avem linii, deci resetam lineCount
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            //in loc de space, o sa fie buton separat, dar momentan las la space
        {
            ScreenshotHandler.TakeScreenshot_Static(Screen.width, Screen.height);
            //salveaza poza, apoi vrem sa stergem canvas-ul

            StartCoroutine(ClearCanvas());
            //codul de stergere e asa de rapid incat sterge liniile inainte sa se exporteze poza
            //asa ca am dat un delay la codul de stergere
        }

        if (Input.GetMouseButtonDown(0))
        {
            lineCount++;
            GameObject newLine = Instantiate(linePrefab);

            newLine.name = "Line " + lineCount.ToString();
            //nume ^

            activeLine = newLine.GetComponent<Line>();

            Renderer renderer = newLine.GetComponent<Renderer>();

            renderer.sortingOrder = lineCount;

            //^ sa apara in ordine inversa, cele mai noi sa apara cel mai sus in hierarchy

            newLine.transform.SetParent(linesParent);
            //^ daca *chiar* vrem sa facem cu layere la un moment dat, cred ca asta ne va ajuta
            //momentan o folosim ca sa putem sterge toate liniile deodata (pt frame nou)
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos.x = Mathf.Clamp(mousePos.x, -9, 6);
            // ^ scuffed, repara

            activeLine.UpdateLine(mousePos);

            //verificam daca e guma

            if(changeBrush.brush == true)
            {
                activeLine.GetComponent<Renderer>().material.color = BrushCol;
            }else
            {
                activeLine.GetComponent<Renderer>().material.color = bgCol;
            }

            Debug.Log("Line Width: " + wSlider.width.ToString()); // Print the width value to the console
            activeLine.SetLineWidth(wSlider.width);
        }
    }
}
