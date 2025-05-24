using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMananger : MonoBehaviour
{

    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    public GameObject pisoRoca;
    public List<GameObject> pisos;
    public GameObject obstaculo1;
    public List<GameObject> obstaculos;
    public caballero jugador;
    private float anchoSprite;
    private int maxBloques = 50;
    public float velocidad = 5f;
    public bool gameOver = false;
    public bool start = false;
    void Start()
    {
        anchoSprite = pisoRoca.GetComponent<SpriteRenderer>().bounds.size.x;

        // Generar bloques de piso en el escenario
        for (int i = 0; i < maxBloques; i++)
        {
            float x = -15 + i * anchoSprite;
            GameObject nuevoPiso = Instantiate(pisoRoca, new Vector2(x, -4.15f), Quaternion.identity);
            pisos.Add(nuevoPiso);
        }

        // Generar un obstáculo cada 5 bloques desde el bloque 2 hasta el 39
        for (int i = 8; i < 40; i += 5)
        {
            Vector3 posPiso = pisos[i].transform.position;
            Vector3 posObstaculo = new Vector3(posPiso.x, 1f, 0);
            obstaculos.Add(Instantiate(obstaculo1, posObstaculo, Quaternion.identity));
        }



    }

    // Update is called once per frame
    void Update()
    {
       if(start == false)
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);

        }
    }


}