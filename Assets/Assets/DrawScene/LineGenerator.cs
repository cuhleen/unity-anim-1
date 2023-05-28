//epic
//codul asta are cam multe chestii in el
//daca chiar incercam, poate am putea sa facem coduri separate pentru mai multe functii

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        GameObject newLine = Instantiate(linePrefab);
        activeLine = newLine.GetComponent<Line>();
        activeLine.SetLineWidth(0.5f);
        activeLine = null;

        GameObject RandomStartLine = GameObject.Find("Line(Clone)");
        Destroy(RandomStartLine);
    }

    bool OnCanvas()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x > -9 && mousePos.x < 6.5 && mousePos.y > -5 && mousePos.y < 5)
            return true;

        return false;
    }

    //PROBLEM!!
    /*
    Oh my god
    so
    when you come from the main menu to the drawing scene
    the width is set to "0" for some reason
    but that's not so bad
    the user just ends up having to modify the width slider on their first launch
    BUT
    if the user DOESN'T CLICK before modifying the width slider
    a line is formed based on how the user MOVED THEIR MOUSE TOWARDS THE SLIDER BAR
    IT LOOKS SO BAD
    I have been trying SEVERAL methods of simulating a fake click
    didn't work
    I tried looking for ways to artifically move the mouse using code
    didn't work
    I tried implementing a flag for first startup/first click
    didn't work

    I'll just click myself when presenting this project and that's it



    why must it be like this


    EDIT AFTER NOT LONGER THAN 3 MINUTES
    wadda hell fixed??????????
    but now a seemingly random and ominous, short and stubby "Line(Clone)" appears in the middle of the screen on startup
    
    EDIT AFTER NOT LONGER THAN 1 MINUTE
    ok adding the 2 lines of code to find that random line wasn't *that* hard
    jeez louise

    Now I just have to remove the swear words I may or may not have used throughout this rather large comment and other variables
     */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && OnCanvas() == true)
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
