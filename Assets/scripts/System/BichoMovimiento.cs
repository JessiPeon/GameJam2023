using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichoMovimiento : MonoBehaviour
{
    private MusicTimer musicTimer;
    [Space(20f)]
    //public float sampleRateToHit = 88200f; //2 segundos
    public float sampleRateToHit = 176400f; //4 segundos
    [Space(20f)]
    public Vector3 coordenadasInicio;
    public Vector3 coordenadasHit;
    public Vector3 coordenadasFinal;
    [Space(20f)]
    public Vector3 coordenadasActuales;
    [Space(20f)]
    public bool spawned = false;
    public bool enUso = false;

    [Space(20f)]
    [Header("DEBUG")]
    public float distancia;
    public float porcentaje;
    public float samplesMoviodos;

    private Bicho bicho;

    private void Awake()
    {
        bicho = this.gameObject.GetComponent<Bicho>();
        bicho.DejarLibre();
    }

    // Start is called before the first frame update
    void Start()
    {
        musicTimer = Sistema.data.musicTimer;
        ReiniciarBicho();
    }

    // Update is called once per frame
    void Update()
    {
  
        if(musicTimer.Samples > (sampleRateToHit - musicTimer.samplesToSpawn) && musicTimer.Samples < sampleRateToHit)
        {
            if (!spawned)
            {
                SpawnearBicho();
            }
            else
            {
                CalcularMovimiento();
                MoverBicho(gameObject);
            }

        }
        else
        {
            if(musicTimer.Samples > sampleRateToHit) {

                if (porcentaje < 1.5f)
                {
                    CalcularMovimiento();
                    MoverBicho(gameObject);
                }
                else
                {
                    if (enUso) {
                        enUso = false;
                        bicho.DejarLibre();
                    }
                    

                }
            
            }
            
            
        }
        
    }

    /// <summary>
    ///reinicia los valores del bicho a los iniciales, para resetearlo
    /// </summary>
    public void ReiniciarBicho()
    {
        coordenadasActuales = new Vector3(coordenadasInicio.x + 20f, coordenadasInicio.y, coordenadasInicio.z);
        gameObject.transform.position = coordenadasActuales;

        coordenadasFinal = new Vector3(coordenadasHit.x - (coordenadasInicio.x - coordenadasHit.x), coordenadasInicio.y, coordenadasInicio.z);
        coordenadasHit = new Vector3(coordenadasHit.x, coordenadasInicio.y, coordenadasInicio.z);

        distancia = Mathf.Abs(coordenadasHit.x - coordenadasInicio.x);

        spawned = false;
        
    }

    /// <summary>
    /// Hace el spawn cuando corresponde que se spawnee para comenzar a moverlo.
    /// </summary>
    public void SpawnearBicho()
    {
        gameObject.transform.position = coordenadasInicio;
        samplesMoviodos = 0;
        spawned = true;
        if (!enUso)
        {
            enUso = true;
            bicho.PonerEnUso();
        }
        
    }


    /// <summary>
    /// Calcula donde deberia moverse el bicho dependiendo de el porcentaje del movimiento
    /// </summary>
    public void CalcularMovimiento()
    {
        samplesMoviodos += musicTimer.DeltaSample;
        porcentaje = samplesMoviodos / musicTimer.samplesToSpawn;
        //Debug.Log("porcentaje " + porcentaje + " | timeActual " + musicTimer.Samples);
        coordenadasActuales = new Vector3(coordenadasInicio.x - (distancia * porcentaje), coordenadasInicio.y, coordenadasInicio.z);
    }

    /// <summary>
    /// Mueve el bicho con los datos calculados en CalcularMovimiento()
    /// </summary>
    public void MoverBicho(GameObject bicho)
    {
        bicho.transform.position = coordenadasActuales;
    }
}
