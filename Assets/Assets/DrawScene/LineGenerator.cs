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

    public int lineCount = 0;

    private ChangeBrush changeBrush;
    private ChangeEraser changeEraser;

    private WidthSliderScript wSlider;

    public Color BrushCol = new Color32(0, 0, 0, 1);
    Color bgCol = new Color32(255, 255, 255, 1);

    public Transform linesParent;
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

    // Update is called once per frame
    void Update()
    {

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

            //Debug.Log("Line Width: " + wSlider.width.ToString());

            activeLine.SetLineWidth(wSlider.width);
        }
    }
}
