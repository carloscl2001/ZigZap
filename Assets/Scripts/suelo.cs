using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suelo : MonoBehaviour
{

    // public Camera camara;
    // public int velocidad;
    public GameObject prefabSuelo;
    public GameObject particula;
    public GameObject meta;
    public GameObject suma;
    public GameObject resta;


    private Vector3 offset;
    private static float valX;
    private static float valZ;
    public static int contador = 0;
    private Rigidbody rb;
    private Vector3 dirreccionActual;


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
        if(other.transform.tag == "Jugador" /* && other.GetComponent<Collision>() != null */){
            // Debug.Log(other.transform.position.x + " " + other.transform.position.z + "antes de crear");
            StartCoroutine(CrearSuelo(this.gameObject));
        }
    }

    IEnumerator CrearSuelo(GameObject suelo){
        contador++;

        if(contador <= 5){
            float ran = Random.Range(0.0f, 1.0f);
            if(ran > 0.5f)
                valX += 6.0f;
            else
                valZ += 6.0f;

            if(ran < 0.08f){
                Instantiate(suma, new Vector3(valX + Random.Range(-3.0f, 3.0f), 2f, valZ + Random.Range(-3.0f, 3.0f)), suma.transform.rotation);
            }
            else if(ran > 0.85f){
                Instantiate(resta, new Vector3(valX + Random.Range(-3.0f, 3.0f), 2f, valZ + Random.Range(-3.0f, 3.0f)), resta.transform.rotation);
            }
            GameObject elnuevosuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        }
        if(contador == 5){
            GameObject final = Instantiate(meta, new Vector3(valX + meta.transform.position.x, 0.0f + meta.transform.position.y, valZ + meta.transform.position.z), meta.transform.rotation) as GameObject;
        }

        yield return new WaitForSeconds(0.5f);
        for(int n = 0; n < 6; n++){    
            suelo.transform.Rotate(new Vector3(0, 2, 0) * 1);
            yield return new WaitForSeconds(0.05f);
            suelo.transform.Rotate(new Vector3(0, -2, 0) * 1);
            yield return new WaitForSeconds(0.05f);
        }
        GameObject particulanueva = Instantiate(particula, new Vector3(this.transform.position.x, 0.5f, this.transform.position.z), particula.transform.rotation) as GameObject;
        suelo.GetComponent<Rigidbody>().isKinematic = false;
        suelo.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(0.5f);
        // yield return new WaitForSeconds(f);
        Destroy(suelo);
        // Debug.Log(suelo.transform.position.x + " " + suelo.transform.position.z + "antes de instanciar");
    }

}
