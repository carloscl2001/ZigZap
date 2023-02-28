using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particulas : MonoBehaviour
{
    public int espera;

    // Start is called before the first frame update
    void Start()
    {
        termina(espera);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator termina(int n){
        yield return new WaitForSeconds(n);
        Destroy(gameObject);
    }
}
