using System;
using UnityEngine;
using UnityEngine.Pool;

public class SistemaDisparos : MonoBehaviour
{
    public static SistemaDisparos instance;

    [SerializeField] private Disparo disparoPrefab;
    private ObjectPool<Disparo> objectPool;

    public ObjectPool<Disparo> ObjectPool { get => objectPool; }

    private void Awake()
    {
        instance = this;
        objectPool = new ObjectPool<Disparo>(CrearDisparo, ActivarDisparo, DesactivarDisparo, DestruirDisparo);
    }

    private Disparo CrearDisparo()
    {
        Disparo disparoCopia = Instantiate(disparoPrefab);
        disparoCopia.MyPool = objectPool;
        return disparoCopia;
    }

    private void ActivarDisparo(Disparo disparo)
    {
        disparo.gameObject.SetActive(true);
    }

    private void DesactivarDisparo(Disparo disparo)
    {
        disparo.gameObject.SetActive(false);
    }

    private void DestruirDisparo(Disparo disparo)
    {
        Destroy(disparo.gameObject);
    }

    public void Disparar(Vector2 posicion, Vector2 direccion)
    {
        Disparo disparo = objectPool.Get();
        disparo.transform.position = posicion;
        disparo.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg);
        disparo.ConfigurarDireccion(direccion);
    }
}