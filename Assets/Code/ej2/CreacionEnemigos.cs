using System.Collections;
using UnityEngine;

public class CreacionEnemigos : MonoBehaviour
{

    [SerializeField] private GameObject enemigoPrefab;
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
        for (int i = 0; i < 20; i++){
            ubicacion = Random.Range(-4f, 4f);
            Vector2 ubicacionRandom = new Vector2(10, ubicacion);
            Instantiate(enemigoPrefab, ubicacionRandom, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
        
    }
}
