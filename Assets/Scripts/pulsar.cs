using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsar : MonoBehaviour
{
    public Button boton;
    public Image image;
    public Sprite[] spNumero;
    public Text texto;

    private bool contar;
    private int numero;
    

    // Start is called before the first frame update
    void Start(){
        //boton = GameObject.FindAnyObjectByType<Button>();
        //boton = GameObject.FindWithTag("boton").GetComponent<Button>();
        boton.onClick.AddListener(Pulsado);
        contar = false;
        numero = 3;
    }

    void Pulsado(){
        Debug.Log("Pulsado");
        image.gameObject.SetActive(true);
        boton.gameObject.SetActive(false);
        contar = true;
    }
    // Update is called once per frame
    void Update(){
        if(contar){
            switch (numero){
                case 0:
                    Debug.Log("Has terminado | Saltando de escena....");
                    break;
                case 1:
                    image.sprite = spNumero[2];
                    texto.text = "1";
                    break;
                case 2:
                    image.sprite = spNumero[1];
                    texto.text = "2";
                    break;
                case 3:
                    image.sprite = spNumero[0];
                    texto.text = "3";
                    break;
            }
            StartCoroutine(Esperar());
            contar = false;
            numero--;
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1);
        contar = true;
    }
}
