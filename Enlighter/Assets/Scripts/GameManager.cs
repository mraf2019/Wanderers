using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameCanvas;
    public GameObject sceneCamera;
    public Joystick joystick;

    public int playersLeft;

    // Other variables and methods

    // Implement the Singleton pattern to ensure only one instance of the GameManager exists
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        playerPrefab.GetComponent<OnlinePlayer>().joystick = joystick;
        SpawnPlayer();
    }

    public void PlayerDestroyed()
    {
        playersLeft--;

        if (playersLeft <= 1)
            EndGame();
    }

    private void EndGame()
    {
        // Show the game over screen or perform other actions
        SceneManager.LoadScene("Result");

        // Restart the game after a certain delay if desired
        // Invoke("RestartGame", 2f);
    }

    private void RestartGame()
    {
        // Reload the current scene or load a specific scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SpawnPlayer()
    {
        float randomX = Random.Range(-30f, 30f);
        float randomY = Random.Range(-30f, 30f);
        PhotonNetwork.Instantiate(playerPrefab.name,
            new Vector2(this.transform.position.x + randomX, this.transform.position.y + randomY),
            Quaternion.identity,
            0);
    }
}
