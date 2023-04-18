using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeEraser : MonoBehaviour
{

    private ChangeBrush changeBrush;

    void Start()
    {
        changeBrush = FindAnyObjectByType<ChangeBrush>();
    }

    void Update()
    {

    }

    public void SetEraser()
    {
        Debug.Log("eraser");
        changeBrush.brush = false;
    }
}
