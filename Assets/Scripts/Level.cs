using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
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
        bool level_3 = false;
        if(other.transform.tag == "Jugador" && level_3 == false){
            SceneManager.LoadScene("escena_3", LoadSceneMode.Single);
        }
    }
}
