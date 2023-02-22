using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Camera camara;
    public int velocidad;
    public GameObject prefabSuelo;

    private Vector3 offset;
    private float valX;
    private float valZ;
    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position;
        valX = 0.0f;
        valZ = 0.0f;
        SueloInicial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SueloInicial(){
        for(int n = 0; n < 3; n++){
            valZ += 6.0f;
            GameObject elsuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        }
    }
}