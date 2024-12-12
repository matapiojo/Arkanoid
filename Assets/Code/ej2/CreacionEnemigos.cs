using System.Collections;
using UnityEngine;

public class CreacionEnemigos : MonoBehaviour
{
    [SerializeField] private SistemaDisparos disparos;
    [SerializeField] private Enemigo enemigoPrefab;
    
    private float ubicacion;
    
    void Start()
    {
        StartCoroutine(SpawnEnemigo());
    }



    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator SpawnEnemigo()
    {
        for (int i = 0; i < 10; i++){
            ubicacion = Random.Range(-4f, 4f);
            Vector2 ubicacionRandom = new Vector2(10, ubicacion);
            Instantiate(enemigoPrefab, ubicacionRandom, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2f,5f));
        }
    }
}
