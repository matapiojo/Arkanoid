using UnityEngine;
using UnityEngine.Pool;

public class Disparo : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float direccion;

    void Start()
    {
        
        //mala practica, queda en memoria
        //Destroy(gameObject,4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(direccion,0)*velocidad * Time.deltaTime);
    }
}
