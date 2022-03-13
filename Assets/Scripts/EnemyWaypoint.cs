using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoint : MonoBehaviour
{
    public Vector3 PointPosition; //el enemy ai la utiliza
    // Start is called before the first frame update

    void Start()
    {
        ProjectLineToFloorWaypoint();
        transform.transform.position = PointPosition;
    }

    void ProjectLineToFloorWaypoint()
    {
        Ray ray = new Ray(transform.position, Vector3.down); //creo un rayo que inicia en la posicion de este objeto hacia abajo

        Vector3 targetPoint = ray.GetPoint(20f);    //guardo ese rallo en targetPoint con un largo de 20

        Debug.DrawLine(transform.position, targetPoint, Color.red, 30f);    //Muestra la linea en el editor por 30 segundos (debug)

        RaycastHit hit; 

        if (Physics.Raycast(transform.position, targetPoint, out hit, 30f)) //si nuestro ray golpea algo
        {
            PointPosition = hit.point;  //guardo la posicion
            //Debug.Log(PointPosition);
        }
    }
}
