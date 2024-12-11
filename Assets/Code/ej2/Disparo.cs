using UnityEngine;
using UnityEngine.Pool;

public class Disparo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private ObjectPool<Disparo> myPoolDisparos;
    private float timer;
    private Vector2 direccion;

    public ObjectPool<Disparo> MyPool { get => myPoolDisparos; set => myPoolDisparos = value; }

    public void ConfigurarDireccion(Vector2 nuevaDireccion)
    {
        direccion = nuevaDireccion.normalized;
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        timer += Time.deltaTime;

        if (timer >= 4)
        {
            timer = 0;
            myPoolDisparos.Release(this);
        }
    }

}
