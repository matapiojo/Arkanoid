using System;
using UnityEngine;
using UnityEngine.Pool;

public class SistemaDisparos : MonoBehaviour
{
    
    public static SistemaDisparos instance;

    [SerializeField] private Disparo disparoPrefab;
    private ObjectPool<Disparo> objectPool;

    public ObjectPool<Disparo> ObjectPool { get => objectPool; set => objectPool = value; }

    private void Awake()
    {
        instance = this;
        objectPool = new ObjectPool<Disparo>(CrearDisparo, GetDisparo, ReleaseDisparo, DestroyDisparo);

    }
    private Disparo CrearDisparo()
    {
        Disparo disparoCopia = Instantiate(disparoPrefab, transform.position, Quaternion.identity);
        disparoCopia.MyPool = objectPool;
        return disparoCopia;
    }
    public void ReleaseDisparo(Disparo disparo)
    {
        disparo.gameObject.SetActive(false);
    }

    private void GetDisparo(Disparo disparo)
    {
        disparo.transform.position = transform.position;
        disparo.gameObject.SetActive(true);
    }

    private void DestroyDisparo(Disparo disparo)
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
