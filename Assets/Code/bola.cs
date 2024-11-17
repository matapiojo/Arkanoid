using Unity.VisualScripting;
using UnityEngine;

public class bulletSpeed : MonoBehaviour
{
    private Rigidbody2D rb;
    bool puedoLanzar =true;
    [SerializeField] float fuerzaImpulso = 10;
    [SerializeField] GameObject pala;
    
    void Start()
    {
       rb = this.gameObject.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && puedoLanzar == true){
            transform.SetParent(null);
            rb.bodyType=RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(1, 1).normalized * fuerzaImpulso, ForceMode2D.Impulse);
            puedoLanzar =false; 
       } 
    }

    private void OnCollisionEnter2D(Collision2D otro)
    {
        if (otro.gameObject.CompareTag("bloque"))
        {
            Destroy(otro.gameObject);
        };
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
    }
}
