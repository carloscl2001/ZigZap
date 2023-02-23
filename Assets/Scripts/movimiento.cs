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
    private int contador;

    // Start is called before the first frame update
    void Start(){
        offset = camara.transform.position;
        valX = 0.0f;
        valZ = 0.0f;
        contador = 0;
        rb = GetComponent<Rigidbody>();
        dirreccionActual = Vector3.forward;
        SueloInicial();
    }

    // Update is called once per frame
    void Update(){
        camara.transform.position = this.transform.position + offset;
        // Debug.Log("antes de girar");
        if (Input.GetKeyUp(KeyCode.Space)){
            if(dirreccionActual == Vector3.forward)
                dirreccionActual = Vector3.right;
            else
                dirreccionActual = Vector3.forward;   
        }
        float tiempo = velocidad * Time.deltaTime;
        // Debug.Log("despues de girar");
        rb.transform.Translate(dirreccionActual * tiempo, Space.World);
        Vector3 pos = this.transform.position;
        // this.transform.position = new Vector3(pos.x, 1, pos.z);
    }

    void SueloInicial(){
        for(int n = 0; n < 3; n++){
            valZ += 6.0f;
            GameObject elsuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        }
    }

/*     void OnCollisionExit(Collision other){
        // Debug.Log("toca suelo");
        if(other.transform.tag == "Suelo"){
            contador++;
            texto.text = "Suelos: " + contador;
            // Debug.Log(other.transform.position.x + " " + other.transform.position.z + "antes de crear");
            StartCoroutine(CrearSuelo(other));
        }
    }

    IEnumerator CrearSuelo(Collision suelo){
        Debug.Log(suelo.transform.position.x + " " + suelo.transform.position.z + " Suelo");
        // yield return new WaitWhile(() => toca);
        yield return new WaitForSeconds(0f);
        Debug.Log(suelo.transform.position.x + " " + suelo.transform.position.z + " destruye suelo");
        suelo.rigidbody.isKinematic = false;
        suelo.rigidbody.useGravity = true;
        // yield return new WaitForSeconds(f);
        Destroy(suelo.gameObject);
        float ran = Random.Range(0.0f, 1.0f);
        if(ran > 0.5f)
            valX += 6.0f;
        else
            valZ += 6.0f;
        // Debug.Log(suelo.transform.position.x + " " + suelo.transform.position.z + "antes de instanciar");
        GameObject elnuevosuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
    }*/
} 