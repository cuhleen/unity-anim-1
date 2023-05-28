using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSqMovementScript : MonoBehaviour
{

    public float moveSpeed = 5;
    //inca nu sunt sigur ca asta chiar face ceva :)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime / 1.5f;

    }
}
