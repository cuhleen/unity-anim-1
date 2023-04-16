using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
//^ librarie pentru scene

public class ButStart : MonoBehaviour
{

    [SerializeField] private string newScene = "DrawScene";

    public void ButtonClick()
    {
        SceneManager.LoadScene(newScene);
    }

}
