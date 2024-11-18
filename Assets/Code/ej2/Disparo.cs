using UnityEngine;

public class Disparo : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float direccion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(direccion,0)*velocidad * Time.deltaTime);
    }
}
