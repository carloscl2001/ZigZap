using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suelo : MonoBehaviour
{

    // public Camera camara;
    // public int velocidad;
    public GameObject prefabSuelo;
    // public Text texto;

    private Vector3 offset;
    private static float valX;
    private static float valZ;
    private Rigidbody rb;
    private Vector3 dirreccionActual;
    private static int contador = 0;

    // Start is called before the first frame update
    void Start()
    {
        valX = this.transform.position.x;
        valZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionExit(Collision other){
        // Debug.Log("toca suelo");
        if(other.transform.tag == "jugador" /* && other.GetComponent<Collision>() != null */){
            contador++;
            Debug.Log("Suelos: " + contador);
            // texto.text = "Suelos: " + contador;
            // Debug.Log(other.transform.position.x + " " + other.transform.position.z + "antes de crear");
            StartCoroutine(CrearSuelo(this.gameObject));
        }
    }

    IEnumerator CrearSuelo(GameObject suelo){
        // Debug.Log(suelo.transform.position.x + " " + suelo.transform.position.z + " Suelo");
        // yield return new WaitWhile(() => toca);
        yield return new WaitForSeconds(0.5f);
        // Debug.Log(suelo.transform.position.x + " " + suelo.transform.position.z + " destruye suelo");
        float ran = Random.Range(0.0f, 1.0f);
        if(ran > 0.5f)
            valX += 6.0f;
        else
            valZ += 6.0f;
        GameObject elnuevosuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        suelo.GetComponent<Rigidbody>().isKinematic = false;
        suelo.GetComponent<Rigidbody>().useGravity = true;
        // yield return new WaitForSeconds(f);
        Destroy(suelo);
        // Debug.Log(suelo.transform.position.x + " " + suelo.transform.position.z + "antes de instanciar");
    }

}
