using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MultiAudioController : MonoBehaviour
{
    [Header("Componentes")]
    private AudioSource audioSource;

    [Header("Lista de Audios")]
    [Tooltip("Arrastra aquí tus 10 archivos MP3")]
    public AudioClip[] listaDeAudios;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Reproduce el audio indicado por su número de lista (0 para el primero, 1 para el segundo, etc.)
    /// </summary>
    public void ReproducirAudioPorIndice(int indice)
    {
        // Validar que el índice sea válido
        if (indice < 0 || indice >= listaDeAudios.Length)
        {
            Debug.LogWarning($"El índice {indice} está fuera del rango de audios disponibles.");
            return;
        }

        if (listaDeAudios[indice] == null)
        {
            Debug.LogWarning($"El audio en el índice {indice} está vacío.");
            return;
        }

        // Si ya está sonando ese mismo audio, lo detiene/reproduce (o puedes usar PlayOneShot)
        audioSource.Stop();
        audioSource.clip = listaDeAudios[indice];
        audioSource.Play();
    }

    /// <summary>
    /// Función opcional para detener cualquier audio sonando
    /// </summary>
    public void DetenerAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}