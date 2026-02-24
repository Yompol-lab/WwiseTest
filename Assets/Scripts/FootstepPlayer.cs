using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    [Header("Wwise Events")]
    public AK.Wwise.Event playFootsteps;   
    public AK.Wwise.Event stopFootsteps;   

    [Header("Movement detect")]
    public float minSpeedToPlay = 0.1f;

    private Vector3 lastPos;
    private bool isPlaying;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        
        float speed = (transform.position - lastPos).magnitude / Mathf.Max(Time.deltaTime, 0.0001f);
        lastPos = transform.position;

        bool moving = speed > minSpeedToPlay;

        if (moving && !isPlaying)
        {
            playFootsteps.Post(gameObject);
            isPlaying = true;
        }
        else if (!moving && isPlaying)
        {
            stopFootsteps.Post(gameObject);
            isPlaying = false;
        }
    }
}
