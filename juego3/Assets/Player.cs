using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 1;
    public Vector3 direction;

    void Start()
    {
        // Movemos de (0,0) a la posici�n que le decimos
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // Almacenar la direcci�n hacia la que el jugador quiere desplazar el personaje este frame. No mover al personaje, solo almacenar esa direcci�n
        direction = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }

        // Normalizar la direcci�n si es necesario
        if (direction.x != 0 || direction.y != 0)
        {
            direction = direction.normalized;
        }

        // Ahora s�, mover al personaje
        gameObject.transform.position += direction * speed * Time.deltaTime;
    }
}