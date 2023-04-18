using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeBrush : MonoBehaviour
{

    void Start()
    {
   
    }

    void Update()
    {

    }

    public bool brush = true;

    public void SetBrush()
    {
        Debug.Log("brush");
        brush = true;
    }
}
