using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    public Camera camara;
    public int velocidad;
    public GameObject prefabSuelo;
    public Text texto;

    private Vector3 offset;
    private float valX;
    private float valZ;
    private Rigidbody rb;
    private Vector3 dirreccionActual;
    private int numSuelos;

    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position;
        valX = 0.0f;
        valZ = 0.0f;
        rb = GetComponent<Rigidbody>();
        dirreccionActual = Vector3.forward;
        numSuelos = 0;
        SueloInicial();
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = this.transform.position + offset;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(dirreccionActual == Vector3.forward)
                dirreccionActual = Vector3.right;
            else
                dirreccionActual = Vector3.forward;   
        }
        float tiempo = velocidad * Time.deltaTime;

        rb.transform.Translate(dirreccionActual * tiempo);
    }

    void SueloInicial(){
        for(int n = 0; n < 3; n++){
            valZ += 6.0f;
            GameObject elsuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        }
    }

    void OnCollisionExit(Collision other){
        if(other.transform.tag == "suelo"){
            numSuelos++;
            texto.text = "Puntuacion: "  + numSuelos;
            StartCoroutine(CrearSuelo(other));
        }
    }

    IEnumerator CrearSuelo(Collision suelo){
        Debug.Log("Suelo");
        yield return new WaitForSeconds(2f);
        suelo.rigidbody.isKinematic = false;
        suelo.rigidbody.useGravity = true;
        yield return new WaitForSeconds(2f);
        Destroy(suelo.gameObject);
        float ran = Random.Range(0.0f, 1.0f);
        if(ran > 0.5f)
            valX += 6.0f;
        else
            valZ += 6.0f;
        GameObject elnuevosuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
    }
}