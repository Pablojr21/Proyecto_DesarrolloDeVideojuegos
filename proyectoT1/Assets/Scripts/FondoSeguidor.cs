using UnityEngine;

public class FondoSeguidor : MonoBehaviour
{

    public Transform camara;
    public float offsetY = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camara.position.x, camara.position.y + offsetY, transform.position.z);
    }
}
