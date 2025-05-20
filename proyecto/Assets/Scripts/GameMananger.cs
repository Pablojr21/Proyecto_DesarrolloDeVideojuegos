using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject pisoRoca;
    public List<GameObject> pisos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (float i = 0f; i < 30f; i += 1f)
        {
            pisos.Add(Instantiate(pisoRoca, new Vector2(-15f + i, -4.15f), Quaternion.identity));
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
