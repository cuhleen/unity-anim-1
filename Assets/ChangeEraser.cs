using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeEraser : MonoBehaviour
{

    private ChangeBrush changeBrush;

    public void brush()
    {
        changeBrush.erase = false;
    }

    //ar trebui sa schimbe erase-ul inapoi in fals, si sa faca culoarea materialului negru
    //dar nu merge
    //xd
}
