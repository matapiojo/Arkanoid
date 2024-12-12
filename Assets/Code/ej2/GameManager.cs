using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public movNave player;
    [SerializeField] private int vidas = 3;
    private float distancia = 0f;
    [SerializeField] private TextMeshProUGUI textoVidas;
    [SerializeField] private TextMeshProUGUI textoPuntaje;
    [SerializeField] private TextMeshProUGUI textoDistancia;
    private int puntaje = 0;
    [SerializeField] private Image gameOverUI;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ActualizarUI();
    }

    public void RestarVida()
    {
        vidas--;
        ActualizarUI();
        if (vidas <= 0)
        {
            vidas = 0;
            GameOver();
        }
    }

    private void Update()
    {
        //Esto no quiere imprimir un número normal con 1 decimal. 
        //distancia = Mathf.Round((Time.deltaTime + distancia) * 10.0f)*0.1f;
        distancia = (Time.deltaTime + distancia);

        ActualizarUI();
    }

    public void AgregarPuntaje(int puntos)
    {
        puntaje += puntos;
        ActualizarUI();
    }

    private void ActualizarUI() // Actualiza interfaz que aún no hago.  
    {
        textoVidas.text = "Vidas: " + vidas;
        textoPuntaje.text = "Puntaje: " + puntaje;
        textoDistancia.text = "Distancia: " + distancia.ToString("F1") + " Km";
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        //Agregar pantalla perdiste o volver a iniciar 
        player.Destruir();
        gameOverUI.gameObject.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit(); 
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
