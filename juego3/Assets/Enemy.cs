using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private Player character;
    private bool retreat = false;

    void Start()
    {
        // Inicialización, si es necesario (no se está usando en este caso)
    }

    void Update()
    {
        if (retreat)
        {
            // Se aleja del personaje
            Vector3 direction = transform.position - character.transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            // Se mueve hacia el personaje
            Vector3 direction = character.transform.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    public void Retreat()
    {
        retreat = true;
    }
}



