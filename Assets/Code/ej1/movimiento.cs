using UnityEngine;

public class movimiento : MonoBehaviour
{

    [SerializeField] float velocidad = 0;
    Rigidbody2D rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(inputH,0) * velocidad * Time.deltaTime);
        float xDemilitado = Mathf.Clamp(transform.position.x, -8.3f, 8.3f);
        transform.position = new Vector3(xDemilitado, transform.position.y, transform.position.z);
    }
}
