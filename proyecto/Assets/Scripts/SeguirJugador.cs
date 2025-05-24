using UnityEngine;

public class SeguirJugador : MonoBehaviour
{


    public Transform jugador; // Arrastra al caballero desde el inspector
    public float offsetX = 2f; // Espacio hacia la derecha del jugador
    public float suavizado = 0.125f;

    private Vector3 posicionInicial; // Limite mínimo de la cámara

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position; // Guarda la posición inicial de la cámara (el límite izquierdo)   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionDeseada = new Vector3(jugador.position.x + offsetX, transform.position.y, transform.position.z);

        // Limita la cámara para que no retroceda más allá del inicio
        if (posicionDeseada.x < posicionInicial.x)
        {
            posicionDeseada.x = posicionInicial.x;
        }

        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, suavizado);
        transform.position = posicionSuavizada;
    }
}
