using System;
using UnityEngine;
using UnityEngine.Pool;

public class SistemaDisparos : MonoBehaviour
{
    [SerializeField] private Disparo disparoPrefab;
    private ObjectPool<Disparo> objectPool;

    private void Awake()
    {
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

      
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparo disparoCopia= objectPool.Get();
            disparoCopia.gameObject.SetActive(true);
        }
    }
}
