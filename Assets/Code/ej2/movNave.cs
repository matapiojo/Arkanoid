using UnityEngine;

public class movNave : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float ratioDisparo;

    private float temporizador = 0.5f;

    void Update()
    {
        Movimiento();
        DemilitadorMovimiento();

        temporizador -= Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space) && temporizador <= 0)
        {
            Vector2 direccionDisparo = Vector2.right; // Disparo hacia la derecha
            SistemaDisparos.instance.Disparar(transform.position, direccionDisparo);
            temporizador = ratioDisparo;
        }

    }


    public void RecibeDanio()
    {
        GameManager.instance.RestarVida();
    }


    void Movimiento()
    {
        float inputV = Input.GetAxisRaw("Vertical");
        float inputH = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(inputH, inputV).normalized * velocidad * Time.deltaTime);
    }

    void DemilitadorMovimiento()
    {
        float xDemilitado = Mathf.Clamp(transform.position.x, -8f, 8f);
        float yDemilitado = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(xDemilitado, yDemilitado, 0);
    }
}
