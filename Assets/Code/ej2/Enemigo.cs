using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private GameObject pulsePrefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private SistemaDisparosEne disparosEne;

    private CreacionEnemigos enemigos;
    
    void AsignarEnemigos()
    {

    }

    void Start()
    {
        StartCoroutine(SpawnDisparo());
    }

    void Update()
    {
        transform.Translate(new Vector2 (-1,0) * velocidad * Time.deltaTime);
    }


    IEnumerator SpawnDisparo()
    {
        for (int i = 0; i < 10; i++)
        {
            disparosEne.ObjectPool.Get();
            yield return new WaitForSeconds(Random.Range(2f,3f));
        }
            
    }

    
}
