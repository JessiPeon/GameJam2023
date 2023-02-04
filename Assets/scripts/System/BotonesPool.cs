using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesPool : MonoBehaviour
{
    public List<Bicho> bichosEnUso;
    public List<Bicho> bichosEnLibres;

    private void Awake()
    {
        if(Sistema.data.botonesPool == null) {
            Sistema.data.botonesPool = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
