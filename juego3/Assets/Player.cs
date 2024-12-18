using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 1;
    public Vector3 direction;

    void Start()
    {
        // Movemos de (0,0) a la posición que le decimos
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // Almacenar la dirección hacia la que el jugador quiere desplazar el personaje este frame. No mover al personaje, solo almacenar esa dirección
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

        // Normalizar la dirección si es necesario
        if (direction.x != 0 || direction.y != 0)
        {
            direction = direction.normalized;
        }

        // Ahora sí, mover al personaje
        gameObject.transform.position += direction * speed * Time.deltaTime;
    }
}