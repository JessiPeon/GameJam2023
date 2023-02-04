using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicho : MonoBehaviour
{
    public string nombre;
    public BichoMovimiento bichoMovimiento;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PonerEnUso()
    {
        Sistema.data.botonesPool.bichosEnLibres.Remove(this);
        Sistema.data.botonesPool.bichosEnUso.Add(this);
    }

    public void DejarLibre()
    {
        Sistema.data.botonesPool.bichosEnUso.Remove(this);
        Sistema.data.botonesPool.bichosEnLibres.Add(this);
        
    }
}
