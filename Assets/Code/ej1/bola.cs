using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class bulletSpeed : MonoBehaviour
{
    private Rigidbody2D rb;
    bool puedoLanzar =true;
    [SerializeField] float fuerzaImpulso = 10;
    [SerializeField] GameObject pala;
    //private float anguloX = UnityEngine.Random.Range((float)0.8, 1);
    //private float anguloY = UnityEngine.Random.Range((float)0.7, 1);
    private int vidas = 3;
    private int puntaje= 0;
    private int HighScore= 0;
        [SerializeField] private TextMeshProUGUI textoScore;
    [SerializeField] private TextMeshProUGUI textoVida;
    [SerializeField] private TextMeshProUGUI textoHighScore;


    void Start()
    {
       rb = this.gameObject.GetComponent<Rigidbody2D>();
        textoVida.text = "Vidas: " + vidas;
        textoScore.text = puntaje + " :Puntaje";
        textoHighScore.text = "HighScore: " + HighScore;

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && puedoLanzar == true){
            transform.SetParent(null);
            rb.bodyType=RigidbodyType2D.Dynamic;
            // nunca funciona con valores random
            //rb.AddForce(new Vector2(anguloX,anguloY).normalized * fuerzaImpulso, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(1,1).normalized * fuerzaImpulso, ForceMode2D.Impulse);
            puedoLanzar =false; 
       } 
    }

    private void OnCollisionEnter2D(Collision2D otro)
    {
        if (otro.gameObject.CompareTag("bloque"))
        {
            Destroy(otro.gameObject);
            puntaje++;
            textoScore.text = puntaje + " :Puntaje";
            if (puntaje > HighScore)
            {
                HighScore = puntaje;
                textoHighScore.text = "HighScore: "+ HighScore;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            ResetBola();   
        }
    }

    private void ResetBola()
    {
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.SetParent(pala.transform);
        transform.localPosition = new Vector3(0, 1, 0);
        puedoLanzar = true;
        vidas--;
        puntaje = 0;
        textoScore.text = puntaje + " :Puntaje";
        textoVida.text = "Vidas: " + vidas;
       if (vidas == 0) { 
            //muere
        }
        
    }
}
