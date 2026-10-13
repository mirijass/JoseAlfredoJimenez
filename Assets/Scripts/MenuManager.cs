using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelComenzar;
    public GameObject panelMenu;
    public GameObject panelBiografia;
    public GameObject panelInstrucciones;

    void Start()
    {
        MostrarPanel(panelComenzar);
    }

    void OcultarTodos()
    {
        panelComenzar.SetActive(false);
        panelMenu.SetActive(false);
        panelBiografia.SetActive(false);
        panelInstrucciones.SetActive(false);
    }

    public void MostrarPanel(GameObject panel)
    {
        OcultarTodos();
        panel.SetActive(true);
    }

    public void IrMenu()
    {
        MostrarPanel(panelMenu);
    }

    public void IrBiografia()
    {
        MostrarPanel(panelBiografia);
    }

    public void IrInstrucciones()
    {
        MostrarPanel(panelInstrucciones);
    }

    public void IrInicio()
    {
        MostrarPanel(panelComenzar);
    }

    // Cargar la escena del Zarape
    public void IrEscenaZarape()
    {
        SceneManager.LoadScene("RealidadAumentada");
    }

    // Regresar a la escena Inicio (opcional)
    public void RegresarInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
}