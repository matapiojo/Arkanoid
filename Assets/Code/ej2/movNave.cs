using UnityEngine;

public class movNave : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float ratioDisparo;
    
    [SerializeField] private SistemaDisparos disparos;
    private float temporizador = 0.5f;

    void Start()
    {
        
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            disparos.ObjectPool.Get();
            //SistemaDisparos.instance.ObjectPool.Get();
        }
    }
}