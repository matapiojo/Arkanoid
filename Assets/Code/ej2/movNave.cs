using UnityEngine;

public class movNave : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float ratioDisparo;
    [SerializeField] private GameObject DisparoPrefab;
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    private float temporizador = 0.5f;

    void Start()
    {
        
    }

    void Disparo()
    {
        temporizador += 1 * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Space) && temporizador > ratioDisparo){   
            Instantiate(DisparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(DisparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            temporizador = 0;
        }
    }

    void Movimiento(){
        float inputV = Input.GetAxisRaw("Vertical");
        float inputH = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(inputH, inputV).normalized * velocidad * Time.deltaTime);
    }

    void DemilitadorMovimiento() {
        //limitar movimiento
        float xDemilitado = Mathf.Clamp(transform.position.x, -8f, 8f);
        float yDemilitado = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(xDemilitado, yDemilitado, 0);
    }

    // Update is called once per frame
    void Update()
    {
       Movimiento();
       DemilitadorMovimiento();
        Disparo();
    }
}