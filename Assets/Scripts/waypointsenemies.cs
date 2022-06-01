using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointsenemies : MonoBehaviour
{
    public Transform zorro;
    public SpriteRenderer sp;
    public Transform flip1;
    public Transform flip2;
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
        if(zorro.position == flip1.position){
            sp.flipX = false;
        }
        if(zorro.position == flip2.position){
            sp.flipX = true;
        }
    }
}
