using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolBichos : MonoBehaviour
{
    public List<Bicho> bichosEnUso;
    public List<Bicho> bichosEnLibres;

    public GameObject bichoAinstanciar;

    public GameObject[] posicionCircle;

    public Dictionary<(int, int), GameObject> bichos = new Dictionary<(int, int), GameObject>();

    private void Awake()
    {
        if(Sistema.data.poolBichos == null) {
            Sistema.data.poolBichos = this;
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

    public void intentarPool(int index, int sample)
    {
        GameObject bichoNuvo = Instantiate(bichoAinstanciar, new Vector3(100f, 100f, 0f), Quaternion.identity);
        Bicho bichonuevoScriptBicho = bichoNuvo.GetComponent<Bicho>();
        bichonuevoScriptBicho.circle = index;
        bichonuevoScriptBicho.bichoMovimiento.sampleRateToHit = sample;
        bichos.Add((index, sample), bichoNuvo);
    }

    public void destoryBicho(int index, int sample)
    {
        //Debug.LogWarning("destroy");
        var tuple = (index, sample);
        bichos.TryGetValue(tuple, out GameObject bicho);
        if (bicho != null)
        {
            //Debug.LogWarning("destuirdo");
            bichos.Remove(tuple);
            Destroy(bicho,0.05f);
        }
    }
}
