using UnityEngine;

public class ShootRevolver : MonoBehaviour
{
    [Header("Configuración del Arma")]
    public float tiempoEntreDisparos = 0.5f;
    private float proximoDisparo = 0f;

    [Header("Configuración de la Bala")]
    
    public GameObject bulletPrefab; 
    public Transform firePoint;     

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= proximoDisparo)
        {
            Disparar();
            proximoDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    void Disparar()
    {
        
        AkUnitySoundEngine.PostEvent("Play_Revolver", gameObject);

        
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogError("Falta asignar el Prefab de la bala o el FirePoint en el script");
        }
    }
}