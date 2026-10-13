using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Función pública para vincular directamente al evento On Click() del botón UI
    public void IrAEscena(string Inicio)
    {
        SceneManager.LoadScene(Inicio);
    }
}