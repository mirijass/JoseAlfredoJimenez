using UnityEngine;
using UnityEngine.UI;

public class VisorLectura : MonoBehaviour
{
    [System.Serializable]
    public class Lectura
    {
        public string titulo;
        public Sprite[] paginas; // Lista de imágenes/páginas para este botón
    }

    [Header("Contenido")]
    public Lectura[] lecturas; // Configura aquí cada canción/opción

    [Header("Referencias UI")]
    public GameObject panelVisor; // El panel emergente con la imagen y botones
    public Image imagenDisplay;   // La imagen donde se mostrará el contenido
    public GameObject botonSiguiente;
    public GameObject botonAnterior;

    private Sprite[] paginasActuales;
    private int indiceActual = 0;

    // Abre el visor cargando la lista de imágenes correspondiente
    public void AbrirLectura(int indiceLectura)
    {
        if (indiceLectura >= 0 && indiceLectura < lecturas.Length)
        {
            paginasActuales = lecturas[indiceLectura].paginas;

            if (paginasActuales != null && paginasActuales.Length > 0)
            {
                indiceActual = 0;
                panelVisor.SetActive(true);
                ActualizarPagina();
            }
        }
    }

    public void SiguientePagina()
    {
        if (indiceActual < paginasActuales.Length - 1)
        {
            indiceActual++;
            ActualizarPagina();
        }
    }

    public void AnteriorPagina()
    {
        if (indiceActual > 0)
        {
            indiceActual--;
            ActualizarPagina();
        }
    }

    public void VolverAlMenu()
    {
        panelVisor.SetActive(false);
    }

    private void ActualizarPagina()
    {
        imagenDisplay.sprite = paginasActuales[indiceActual];

        // Activa o desactiva botones según la página actual
        if (botonAnterior != null)
            botonAnterior.SetActive(indiceActual > 0);

        if (botonSiguiente != null)
            botonSiguiente.SetActive(indiceActual < paginasActuales.Length - 1);
    }
}
