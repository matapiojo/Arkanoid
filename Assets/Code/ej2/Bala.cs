using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class Bala : MonoBehaviour
{

    [SerializeField] private float velocidad;
    private ObjectPool<Bala> myPool;
    private float timer;

    public ObjectPool<Bala> MyPool { get => myPool; set => myPool = value; }

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
            myPool.Release(this);
        }
    }
}
