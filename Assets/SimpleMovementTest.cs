using UnityEngine;

public class SimpleMovementTest : MonoBehaviour
{
    public float speed = 5f;
    public float tiempoEntrePasos = 0.5f; 

    private float contadorPasos = 0f;

    void Update()
    {
        
        float x = 0f; 
        float z = 0f; 

        if (Input.GetKey(KeyCode.W)) z = 1f;
        else if (Input.GetKey(KeyCode.S)) z = -1f;

        if (Input.GetKey(KeyCode.D)) x = 1f;
        else if (Input.GetKey(KeyCode.A)) x = -1f;

        
        Vector3 move = transform.right * x + transform.forward * z;

        
        bool nosMovemos = move.magnitude > 0.1f;

        if (nosMovemos)
        {
            
            transform.Translate(move * speed * Time.deltaTime, Space.World);

            
            contadorPasos -= Time.deltaTime;

            if (contadorPasos <= 0f)
            {
                
                AkSoundEngine.PostEvent("Play_Footsteps", gameObject);

                
                contadorPasos = tiempoEntrePasos;
            }
        }
        else
        {
            contadorPasos = 0f; 
        }
    }
}