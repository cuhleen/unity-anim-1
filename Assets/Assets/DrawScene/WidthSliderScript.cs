using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WidthSliderScript : MonoBehaviour
{

    [SerializeField] private Slider _widthSlider;
    public float width;

    // Start is called before the first frame update
    void Start()
    {
        _widthSlider.onValueChanged.AddListener((v) =>
        {
            width = v;
            Debug.Log(width);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
