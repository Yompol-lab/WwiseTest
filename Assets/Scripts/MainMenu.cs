using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Configuración de Audio")]
    public float tiempoDeEspera = 2f;

    public void Jugar()
    {
        StartCoroutine(TransicionConAudio("SampleScene"));
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        StartCoroutine(SalirConAudio());
    }

    public void VolverJugar()
    {
        StartCoroutine(TransicionConAudio("SampleScene"));
    }

    public void VolverMenu()
    {
        StartCoroutine(TransicionConAudio("Menu"));
    }

    public void Credits()
    {
        StartCoroutine(TransicionConAudio("Credits"));
    }

    

    private IEnumerator TransicionConAudio(string nombreEscena)
    {
       
        AkSoundEngine.PostEvent("Stop_MenuMusic", this.gameObject);

        
        yield return new WaitForSeconds(tiempoDeEspera);

        
        SceneManager.LoadScene(nombreEscena);
    }

    private IEnumerator SalirConAudio()
    {
        
        AkSoundEngine.PostEvent("Stop_MenuMusic", this.gameObject);

       
        yield return new WaitForSeconds(tiempoDeEspera);

       
        Application.Quit();
    }
}