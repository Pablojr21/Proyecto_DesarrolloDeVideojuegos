using UnityEngine;

public class SeguirJugador : MonoBehaviour
{


    public Transform jugador; // Arrastra al caballero desde el inspector
    public float offsetX = 2f; // Espacio hacia la derecha del jugador
    public float suavizado = 0.125f;

    private Vector3 posicionInicial; // Limite m�nimo de la c�mara

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position; // Guarda la posici�n inicial de la c�mara (el l�mite izquierdo)   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionDeseada = new Vector3(jugador.position.x + offsetX, transform.position.y, transform.position.z);

        // Limita la c�mara para que no retroceda m�s all� del inicio
        if (posicionDeseada.x < posicionInicial.x)
        {
            posicionDeseada.x = posicionInicial.x;
        }

        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, suavizado);
        transform.position = posicionSuavizada;
    }
}
