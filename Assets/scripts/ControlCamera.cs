using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 positionOffset;

    void Start()
    {
        // Calcula y guarda el desplazamiento inicial entre la c�mara y el personaje
        positionOffset = transform.position - player.transform.position;
    }

    void Update()
    {
        // Actualiza solo la posici�n X de la c�mara basada en la posici�n X del personaje, manteniendo las posiciones Y y Z originales de la c�mara
        transform.position = new Vector3(player.transform.position.x + positionOffset.x, transform.position.y, transform.position.z);
    }
}
