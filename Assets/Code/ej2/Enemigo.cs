using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float anguloMaximo = 45f;

    private Transform objetivo;

    void Start()
    {
        objetivo = GameObject.FindWithTag("Player").transform; // La nave debe tener el tag "Player"
        StartCoroutine(SpawnDisparo());
    }

    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }

   /*IEnumerator SpawnDisparo()
    {
        while (true)
        {
            if (objetivo != null)
            {
                Vector2 direccionDisparo = (objetivo.position - spawnPoint.position).normalized;
                SistemaDisparos.instance.Disparar(spawnPoint.position, direccionDisparo);
            }
            yield return new WaitForSeconds(Random.Range(2f, 3f));
        }
    }
   */

    IEnumerator SpawnDisparo()
    {
        while (true)
        {
            if (objetivo != null)
            {
                Vector2 direccionDisparo = (objetivo.position - spawnPoint.transform.position).normalized;

                // Calcula el ángulo entre la dirección actual y el frente del enemigo
                float angulo = Vector2.Angle(-transform.right, direccionDisparo);

                // Si el ángulo está dentro del rango permitido, dispara
                if (angulo <= anguloMaximo)
                {
                    SistemaDisparos.instance.Disparar(spawnPoint.transform.position, direccionDisparo);
                }
            }
            yield return new WaitForSeconds(Random.Range(2f, 3f));
        }
    }
}
