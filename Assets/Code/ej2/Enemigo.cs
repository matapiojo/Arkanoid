using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private GameObject pulsePrefab;
    [SerializeField] private GameObject spawnPoint;
    
    void Start()
    {
        StartCoroutine(SpawnDisparo());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2 (-1,0) * velocidad * Time.deltaTime);
    }


    IEnumerator SpawnDisparo()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(pulsePrefab, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
            
    }

    
}
