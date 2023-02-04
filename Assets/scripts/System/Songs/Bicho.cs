using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicho : MonoBehaviour
{
    public string nombre;
    public BichoMovimiento bichoMovimiento;

    public int circle;

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
        Sistema.data.poolBichos.bichosEnLibres.Remove(this);
        Sistema.data.poolBichos.bichosEnUso.Add(this);
    }

    public void DejarLibre()
    {
        Sistema.data.poolBichos.bichosEnUso.Remove(this);
        Sistema.data.poolBichos.bichosEnLibres.Add(this);
        
    }
}
