using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeBrush : MonoBehaviour
{

    public bool erase = false;

    public GameObject linePrefab;

    public void brush()
    {
        erase = true;
    }
}
