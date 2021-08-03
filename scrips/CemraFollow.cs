using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemraFollow : MonoBehaviour
{

    public GameObject follow;

    public Vector2 MinCamPos, MaxCamPos; //Minimos y maximos de la camara
    public float smoothTime; //Suavisar movimiento de la camara
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime); ;
        transform.position = new Vector3(
            Mathf.Clamp(posX, MinCamPos.x, MaxCamPos.x),
            Mathf.Clamp(posY, MinCamPos.y, MaxCamPos.y),
            transform.position.z);
    }
}
