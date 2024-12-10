using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class Disparo : MonoBehaviour
{

    [SerializeField] private float velocidad;
    private ObjectPool<Disparo> myPool;
    private float timer;

    public ObjectPool<Disparo> MyPool { get => myPool; set => myPool = value; }

    void Start()
    {
        Debug.Log(MyPool.CountActive);
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
            myPool.Release(this);
        }
    }
}
