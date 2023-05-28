using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SqSpawnScript : MonoBehaviour
{

    public GameObject TitleSq;
    public GameObject WholeAhhTitle;
    public float spawnRate = 3;
    //inca nu sunt sigur ca asta chiar face ceva
    private float timer = 0;
    //la timerul asta conteaza mai mult manipularea (adunarea cu o impartire/inmultire de la Time.deltaTime) decat valoarea lui in sine

    // Start is called before the first frame update
    void Start()
    {
        //problema e ca patratele apar in fata textului
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
            timer += Time.deltaTime * 3.9f;
        else
        {
            GameObject newSq = Instantiate(TitleSq, transform.position, transform.rotation);
            newSq.transform.parent = gameObject.transform;
            float size = 0.028f;
            newSq.transform.localScale = new Vector3(size / 2, size, 0.1f);
            timer = 0;
            Destroy(newSq, 7f);
        }

        
    }
}
