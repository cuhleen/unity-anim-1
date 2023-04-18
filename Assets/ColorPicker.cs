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

    public ColorEvent OnColorSelect;

    RectTransform Rect;
    Texture2D ColorTexture;

    LineGenerator lineGen;

    

    public TextMeshProUGUI DebugText;

    // Start is called before the first frame update
    void Start()
    {
        Rect= GetComponent<RectTransform>();
        ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
        lineGen = FindAnyObjectByType<LineGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition))
        {
            Vector2 delta;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);

            //^ = poz mouse cand punctul O(0, 0) (ancora) este pe mijlocul imaginii

            float width = Rect.rect.width;
            float height = Rect.rect.height;
            delta += new Vector2(width * 0.5f, height * 0.5f);

            //^ = poz mouse cand ancora este in stanga jos la imagine

            float x = Mathf.Clamp(delta.x / width, 0f, 1f);
            float y = Mathf.Clamp(delta.y / height, 1f, 0f);

            //^ = poz mouse cand ancora este in stanga jos la imagine, si cand valorile sunt intre 0 si 1

            int texX = Mathf.RoundToInt(x * ColorTexture.width);
            int texY = Mathf.RoundToInt(y * ColorTexture.height);

            //^ = poz mouse ca si sus dar cu valori care corespund la inaltimea si latimea imaginii

            Color color = ColorTexture.GetPixel(texX, texY);

            //^ incredibil

            string debug = texX + " " + texY;

            DebugText.text = debug;

            DebugText.color = color;

            Debug.Log(texX + " " + texY);

            if (Input.GetMouseButtonDown(0))
            {
                OnColorSelect?.Invoke(color);
                
                lineGen.BrushCol = color;
            }

        }

    }
}
