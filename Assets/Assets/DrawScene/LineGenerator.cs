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

    public Color BrushCol = new Color32(255, 0, 0, 1);
    Color bgCol = new Color32(120, 120, 120, 1);

    private void Start()
    {
        changeBrush = FindAnyObjectByType<ChangeBrush>();
        changeEraser = FindAnyObjectByType<ChangeEraser>();
        
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
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos.x = Mathf.Clamp(mousePos.x, -9, 7);
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
        }
    }
}
