using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using UnityEngine.Events;

[Serializable]
public class ColorEvent : UnityEvent<Color> { }


public class ColorPicker : MonoBehaviour
{

    public ColorEvent OnColorPreview;
    public ColorEvent OnColorSelect;
    

    RectTransform Rect;
    Texture2D ColorTexture;

    LineGenerator lineGen;

    public TextMeshProUGUI DebugText;

    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
        ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
        lineGen = FindAnyObjectByType<LineGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, Camera.main, out Vector2 delta))
        {
            
            ///RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, Camera.main, out delta);

            //^ = poz mouse cand punctul O(0, 0) (ancora) este pe mijlocul imaginii

            ///string debug = "mousePos " +  Input.mousePosition;
            ///debug += "<br> delta " + delta;


            float width = Rect.rect.width;
            float height = Rect.rect.height;
            delta += new Vector2(width * .5f, height * .5f);

            ///debug += "<br> offset delta " + delta;

            //^ = poz mouse cand ancora este in stanga jos la imagine

            float x = Mathf.Clamp(delta.x / width, 0f, 1f);
            float y = Mathf.Clamp(delta.y / height, 0f, 1f);

            //^ = poz mouse cand ancora este in stanga jos la imagine, si cand valorile sunt intre 0 si 1

            int texX = Mathf.RoundToInt(x * ColorTexture.width - 1);
            int texY = Mathf.RoundToInt(y * ColorTexture.height - 1);

            //^ = poz mouse ca si sus dar cu valori care corespund la inaltimea si latimea imaginii

            Color color = ColorTexture.GetPixel(texX, texY);

            //^ incredibil

            DebugText.text = Math.Round(delta.x, 2) + "<br>" + Math.Round(delta.y, 2);
            ///DebugText.color = color;
            ///ratio

            OnColorPreview?.Invoke(color);

            if(delta.x >= 0 && delta.x < Rect.rect.width && delta.y >= 0 && delta.y < Rect.rect.height)
                if (Input.GetMouseButtonDown(0))
                {
                    OnColorSelect?.Invoke(color);
                
                    lineGen.BrushCol = color;
                }

        }

    }
}
