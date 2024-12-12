using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float anguloMaximo = 45f;
    private float limiteIzq = -10f;

    private Transform objetivo;

    void Start()
    {
        // La nave debe tener el tag "Player"
        objetivo = GameObject.FindWithTag("Player").transform;
        StartCoroutine(SpawnDisparo());
    }

    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        if (transform.position.x < limiteIzq)
        {
            Destroy(gameObject);
        }
    }

     IEnumerator SpawnDisparo()
    {
        while (true)
        {
            if (objetivo != null)
            {
                Vector2 direccionDisparo = (objetivo.position - spawnPoint.transform.position).normalized;

                // Calcula el ángulo para disparar, esto fue un parto... el -transform
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
