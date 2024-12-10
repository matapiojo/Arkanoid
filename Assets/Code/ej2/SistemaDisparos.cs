using System;
using UnityEngine;
using UnityEngine.Pool;

public class SistemaDisparos : MonoBehaviour
{
    
    public static SistemaDisparos instance;

    [SerializeField] private Bala disparoPrefab;
    private ObjectPool<Bala> objectPool;

    public ObjectPool<Bala> ObjectPool { get => objectPool; set => objectPool = value; }

    private void Awake()
    {
        instance = this;
        objectPool = new ObjectPool<Bala>(CrearDisparo, GetDisparo, ReleaseDisparo, DestroyDisparo);

    }
    private Bala CrearDisparo()
    {
        Bala disparoCopia = Instantiate(disparoPrefab, transform.position, Quaternion.identity);
        disparoCopia.MyPool = objectPool;
        return disparoCopia;
    }
    public void ReleaseDisparo(Bala disparo)
    {
        disparo.gameObject.SetActive(false);
    }

    private void GetDisparo(Bala disparo)
    {
        disparo.transform.position = transform.position;
        disparo.gameObject.SetActive(true);
    }

    private void DestroyDisparo(Bala disparo)
    {
        Destroy(disparo.gameObject);
    }

      
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bala disparoCopia= objectPool.Get();
            disparoCopia.gameObject.SetActive(true);
        }
    }*/
}
