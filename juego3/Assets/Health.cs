using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float minHealth = 0;

    [SerializeField] Image healthImageUI;
    [SerializeField] GameObject defeatScreen;
    [SerializeField] TMP_Text finalText;

    [SerializeField] private Player player;

    private float playTime = 0f; // Tiempo total jugado
    private Points pointsSystem;   // Referencia al sistema de puntos

    void Start()
    {
        pointsSystem = FindObjectOfType<Points>();
        StartGame();
    }

    void Update()
    {
        // Actualizar el tiempo de juego mientras el personaje está vivo
        if (currentHealth > minHealth)
        {
            playTime += Time.deltaTime;
        }

        if (currentHealth <= minHealth)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthImageUI.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= minHealth)
        {
            Death();
        }
    }

    public void Death()
    {
        defeatScreen.SetActive(true);

        player.enabled = false;

        // Muestra el tiempo jugado y los puntos
        finalText.text = $"You survived for {playTime:F1} seconds and gathered {pointsSystem.GetPoints()} points."; //F1 define cuantos decimales muestra

        // Notificar a los enemigos
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.Retreat();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
        currentHealth = maxHealth;
        healthImageUI.fillAmount = currentHealth / maxHealth;
        defeatScreen.SetActive(false);
        playTime = 0f; // Reiniciar el contador de tiempo
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10f);
        }
    }
}


