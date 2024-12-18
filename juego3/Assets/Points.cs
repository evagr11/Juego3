using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public float minX = -12f;
    public float maxX = 12;
    public float minY = -4.65f;
    public float maxY = 4.65f;

    [SerializeField] TMP_Text scoreUI;
    private int score = 0;

    void Start()
    {
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);
        transform.position = new Vector2(X, Y);
        scoreUI.gameObject.SetActive(false);
    }

    void Update()
    {
        // Rotar el objeto
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Generar una nueva posición aleatoria
            float X = Random.Range(minX, maxX);
            float Y = Random.Range(minY, maxY);
            transform.position = new Vector2(X, Y);

            // Activar la UI de la puntuación
            scoreUI.gameObject.SetActive(true);

            // Incrementar la puntuación y actualizar la UI
            score++;
            scoreUI.text = score.ToString();
        }
    }

    // Obtener los puntos actuales
    public int GetPoints()
    {
        return score;
    }
}


