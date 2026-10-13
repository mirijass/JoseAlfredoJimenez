using System.Collections;
using UnityEngine;

public class AnimarBoton : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Tiempo en segundos que tarda en escalar")]
    public float duracion = 0.35f;

    private Vector3 escalaObjetivo;
    private bool escalaGuardada = false;

    private void Awake()
    {
        GuardarEscalaOriginal();
    }

    private void OnEnable()
    {
        GuardarEscalaOriginal();
        IniciarAnimacion();
    }

    // Esta función guarda la escala solo cuando el objeto NO está en cero
    private void GuardarEscalaOriginal()
    {
        if (!escalaGuardada && transform.localScale != Vector3.zero)
        {
            escalaObjetivo = transform.localScale;
            escalaGuardada = true;
        }
    }

    // Función pública invocable directamente desde Vuforia
    public void IniciarAnimacion()
    {
        StopAllCoroutines();
        StartCoroutine(RutinaAnimar());
    }

    private IEnumerator RutinaAnimar()
    {
        // Si no se guardó escala, asignamos la escala por defecto de la imagen (7.0692)
        if (escalaObjetivo == Vector3.zero)
            escalaObjetivo = new Vector3(7.0692f, 7.0692f, 7.0692f);

        float tiempo = 0f;
        transform.localScale = Vector3.zero;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float progreso = Mathf.SmoothStep(0f, 1f, tiempo / duracion);
            transform.localScale = Vector3.Lerp(Vector3.zero, escalaObjetivo, progreso);
            yield return null;
        }

        transform.localScale = escalaObjetivo;
    }
}