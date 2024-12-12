using UnityEngine;
using UnityEngine.Pool;

public class Disparo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private ObjectPool<Disparo> myPoolDisparos;
    private float timer;
    private Vector2 direccion;


    public ObjectPool<Disparo> MyPool { get => myPoolDisparos; set => myPoolDisparos = value; }

    public void ConfigurarDireccion(Vector2 nuevaDireccion)
    {
        direccion = nuevaDireccion.normalized;
    }



    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        timer += Time.deltaTime;

        if (timer >= 4)
        {
            timer = 0;
            myPoolDisparos.Release(this);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica la dirección en X de la bala
        if (direccion.x > 0 && collision.CompareTag("Enemigo")) // Bala hacia la derecha (jugador dispara)
        {
            //Debug.Log("Bala del jugador golpeó a un enemigo.");
            Destroy(collision.gameObject); // Destruye al enemigo
            myPoolDisparos.Release(this); // Libera la bala
            GameManager.instance.AgregarPuntaje(10); // Aumenta el puntaje
            
        }
        else if (direccion.x < 0 && collision.CompareTag("Player")) // Bala hacia la izquierda (enemigo dispara)
        {
            //Debug.Log("Bala de un enemigo golpeó al jugador.");
            movNave jugador = collision.GetComponentInParent<movNave>();
            Debug.Log(jugador);
            if (jugador != null)
            {
                jugador.RecibeDanio(); // Reduce la vida del jugador
            }
            myPoolDisparos.Release(this); // Libera la bala
        }
    }
}