using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInterval = 5f;
    private float elapsedTime = 0;

    // Prefabs de los enemigos
    [SerializeField] GameObject enemy;

    // Posiciones de spawn para los enemigos 
    [SerializeField] Vector2 spawnPosition1;
    [SerializeField] Vector2 spawnPosition2;
    [SerializeField] Vector2 spawnPosition3;
    [SerializeField] Vector2 spawnPosition4;

    // Velocidades de los enemigos
    [SerializeField] float speed1;
    [SerializeField] float speed2;
    [SerializeField] float speed3;
    [SerializeField] float speed4;

    // Colores de los enemigos
    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    [SerializeField] Color color4;

    void Start()
    {
        // Inicializar o configurar cualquier condición inicial si es necesario
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            SpawnEnemies();
            elapsedTime = 0;
        }
    }

    void SpawnEnemies()
    {
        int randomIndex = Random.Range(1, 5);

        GameObject selectedEnemy = null;
        Vector2 selectedSpawnPosition = Vector3.zero;
        float selectedSpeed = 0f;
        Color selectedColor = Color.white;

        if (randomIndex == 1)
        {
            selectedEnemy = enemy;
            selectedSpawnPosition = spawnPosition1;
            selectedSpeed = speed1;
            selectedColor = color1;
        }
        else if (randomIndex == 2)
        {
            selectedEnemy = enemy;
            selectedSpawnPosition = spawnPosition2;
            selectedSpeed = speed2;
            selectedColor = color2;
        }
        else if (randomIndex == 3)
        {
            selectedEnemy = enemy;
            selectedSpawnPosition = spawnPosition3;
            selectedSpeed = speed3;
            selectedColor = color3;
        }
        else if (randomIndex == 4)
        {
            selectedEnemy = enemy;
            selectedSpawnPosition = spawnPosition4;
            selectedSpeed = speed4;
            selectedColor = color4;
        }

        if (selectedEnemy != null)
        {
            GameObject spawnedEnemy = Instantiate(selectedEnemy, selectedSpawnPosition, Quaternion.identity);

            Enemy enemyScript = spawnedEnemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.speed = selectedSpeed;  // Asignar la velocidad
                enemyScript.GetComponent<SpriteRenderer>().color = selectedColor;  // Asignar el color
            }
        }
    }
}








