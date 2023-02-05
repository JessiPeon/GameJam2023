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
    private ResultadoNota resultadoScript;

    private void Awake()
    {
        bicho = this.gameObject.GetComponent<Bicho>();
        bicho.DejarLibre();
        coordenadasInicio = Sistema.data.poolBichos.posicionCircle[bicho.circle].transform.position;
        resultadoScript = gameObject.GetComponent<ResultadoNota>();
        //Debug.Log("Sample Rate on spawn " + Sistema.data.musicTimer.Samples);
        //Debug.Log("yo deberia haber spawneado en  " + (sampleRateToHit - Sistema.data.musicTimer.samplesToSpawn));
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
                if (porcentaje < 1f)
                {
                    CalcularMovimiento();
                    MoverBicho(gameObject);
                }
                else if (porcentaje < 1.5f)
                {
                    //Debug.Log("me destruy en " + Sistema.data.musicTimer.Samples);
                    //Debug.Log("yo deberia haberme destruido en " + sampleRateToHit);
                    //Debug.Log("falle " + (Sistema.data.musicTimer.Samples - sampleRateToHit));
                    
                    CalcularMovimiento();
                    MoverBicho(gameObject);
                }
                else
                {
                    CalcularMovimiento();
                    MoverBicho(gameObject);

                    Debug.Log("Miss" + Time.time);
                    //bicho.circle;
                    //sampleRateToHit

                    int indiceListaLoca = 0;
                    int[] ListaLoca = Sistema.data.renderSong.listaCirclesCheck[bicho.circle];
                    for (int i = 0; i < ListaLoca.Length; i++)
                    {
                        if(Sistema.data.renderSong.listaCircles[bicho.circle][i] == sampleRateToHit)
                        {
                            indiceListaLoca = i; break;
                        }
                    }

                    if(Sistema.data.renderSong.listaCirclesCheck[bicho.circle][indiceListaLoca] == 1)
                    {

                    }
                    else
                    {
                        Sistema.data.muestraMensajeBoton.instanciarBotonEfect(bicho.circle + 1, 5);
                        resultadoScript = GameObject.Find("Sistema").GetComponent<ResultadoNota>();
                        resultadoScript.SacaBad();
                        Sistema.data.renderSong.listaCirclesCheck[bicho.circle][indiceListaLoca] = 1;
                    }

                    
                    Destroy(this.gameObject, 0.1f);
                    
                }
            
            }
            
            
        }
        
    }

    /// <summary>
    ///reinicia los valores del bicho a los iniciales, para resetearlo
    /// </summary>
    public void ReiniciarBicho()
    {
      
            coordenadasInicio = Sistema.data.poolBichos.posicionCircle[bicho.circle].transform.position;

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
