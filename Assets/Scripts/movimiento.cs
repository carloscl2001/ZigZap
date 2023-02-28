using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movimiento : MonoBehaviour
{
    public Camera camara;
    public int velocidad;
    public GameObject prefabSuelo;
    public GameObject particulaSum;
    public GameObject particulaRes;
    public Text texto;
    public Text texto_velo;

    private Vector3 offset;
    private static int nivel = 2;
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
        suelo.contador = 0;
        SueloInicial();
    }

    // Update is called once per frame
    void Update(){
        transform.Rotate(new Vector3(180, 0, 0) * Time.deltaTime, Space.Self);
        camara.transform.position = this.transform.position + offset;
        // Debug.Log("antes de girar");
        if (Input.GetKeyUp(KeyCode.Space)){
            if(dirreccionActual == Vector3.forward){
                dirreccionActual = Vector3.right;
                transform.rotation = Quaternion.Euler(0, 90, 0);
            } 
            else{
                dirreccionActual = Vector3.forward;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        float tiempo = velocidad * Time.deltaTime;
        // Debug.Log("despues de girar");
        rb.transform.Translate(dirreccionActual * tiempo, Space.World);
        Vector3 pos = this.transform.position;

        if(transform.position.y < -5 || velocidad <= 0){
            SceneManager.LoadScene("escena_" + nivel, LoadSceneMode.Single);
        }
        // this.transform.position = new Vector3(pos.x, 1, pos.z);
    }

    void SueloInicial(){
        for(int n = 0; n < 3; n++){
            valZ += 6.0f;
            GameObject elsuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.tag == "Level"){
            nivel++;
            SceneManager.LoadScene("escena_" + nivel, LoadSceneMode.Single);
        }
        if(other.transform.tag == "Suma" ){
            velocidad += 4;
            texto_velo.text = "Velocidad: " + velocidad;
            Instantiate(particulaSum, new Vector3(this.transform.position.x, 1f, this.transform.position.z), particulaSum.transform.rotation);
            Destroy(other.gameObject);
        }
        if(other.transform.tag == "Resta" ){
            velocidad -= 2;
            texto_velo.text = "Velocidad: " + velocidad;
            Instantiate(particulaRes, new Vector3(this.transform.position.x, 2f, this.transform.position.z), particulaRes.transform.rotation);
            Destroy(other.gameObject);
        }
        if(other.transform.tag == "Obstaculo"){
            SceneManager.LoadScene("escena_" + nivel, LoadSceneMode.Single);
        }
    }

     void OnCollisionExit(Collision other){
        // Debug.Log("toca suelo");
        if(other.transform.tag == "Suelo"){
            contador++;
            texto.text = "Suelos: " + contador;
        }
    }

    
} 