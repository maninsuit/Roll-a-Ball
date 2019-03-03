using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrolcu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject oyuncu;
    private Vector3 ofset;
    void Start()
    {
        ofset = transform.position - oyuncu.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position  = oyuncu.transform.position + ofset;
    }
}
