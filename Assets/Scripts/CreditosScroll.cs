using UnityEngine;

public class CreditosScroll : MonoBehaviour
{
    [Header("Velocidad del Texto")]
    [Tooltip("Cuanto más alto el número, más rápido sube.")]
    public float velocidadSubida = 100f;

    
    void Update()
    {
        
        transform.Translate(Vector3.up * velocidadSubida * Time.deltaTime);
    }
}