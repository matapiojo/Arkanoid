using System.Collections;
using Unity.Collections;
using UnityEngine;

public class CreacionEnemigos : MonoBehaviour
{
    [SerializeField] private SistemaDisparos disparos;
    [SerializeField] private Enemigo enemigoPrefab;
    private Vector3 ubicacionPantalla;
    
    void Start()
    {
        
        StartCoroutine(SpawnEnemigo());
    }

    IEnumerator SpawnEnemigo()
    {
        for (int i = 0; i < 10; i++){
            ubicacionPantalla = Camera.main.ViewportToWorldPoint(new Vector3(1f, Random.value, 1f))+ Vector3.right;
            Instantiate(enemigoPrefab, ubicacionPantalla, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2f,5f));
        }
    }
}
