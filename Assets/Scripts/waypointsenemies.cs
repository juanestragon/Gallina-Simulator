using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointsenemies : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    public float velocidad;
    public float distanciaCambio;
    int siguienteposicion = 0;
    
    
    void Start()
    {

    }


    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position,
                                                 wayPoints[siguienteposicion].transform.position,
                                                 velocidad * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, wayPoints[siguienteposicion].transform.position) < distanciaCambio)
        {
            siguienteposicion++;
            if (siguienteposicion >= wayPoints.Count)
            siguienteposicion = 0;
            
        }
    }
}
