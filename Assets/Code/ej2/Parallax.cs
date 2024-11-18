using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Parallax : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;
    [SerializeField] private float anchoImagen;

    private Vector3 posicionInicial;
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float resto = (velocidad * Time.time) % anchoImagen;
        transform.position = posicionInicial + resto * direccion;
    }
}