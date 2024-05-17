using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 positionOffset;

    void Start()
    {
        // Calcula y guarda el desplazamiento inicial entre la cámara y el personaje
        positionOffset = transform.position - player.transform.position;
    }

    void Update()
    {
        // Actualiza solo la posición X de la cámara basada en la posición X del personaje, manteniendo las posiciones Y y Z originales de la cámara
        transform.position = new Vector3(player.transform.position.x + positionOffset.x, transform.position.y, transform.position.z);
    }
}
