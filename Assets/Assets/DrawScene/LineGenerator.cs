using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{

    public GameObject linePrefab;

    Line activeLine;

    private ChangeBrush changeBrush;

    private void Start()
    {
        changeBrush = FindAnyObjectByType<ChangeBrush>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
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

            if(changeBrush.erase == true)
            {
                activeLine.GetComponent<Renderer>().material.color = Color.white;
            }
            else
            {
                activeLine.GetComponent<Renderer>().material.color = Color.black;
                changeBrush.erase = false;
            }
        }
    }
}
