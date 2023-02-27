using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionExit(Collision other){
        if(other.transform.tag == "Jugador"){
            SceneManager.LoadScene("escena_4", LoadSceneMode.Single);
        }
    }
}
