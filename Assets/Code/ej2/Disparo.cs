using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class Disparo : MonoBehaviour
{

    [SerializeField] private float velocidad;
    private ObjectPool<Disparo> myPoolDisparos;
    private float timer;

    public ObjectPool<Disparo> MyPool { get => myPoolDisparos; set => myPoolDisparos = value; }

    void Start()
    {
        //mala practica, queda en memoria
        //Destroy(gameObject,4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * velocidad * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= 4) {
            timer = 0;
            myPoolDisparos.Release(this);
        }
    }
}
