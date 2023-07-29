using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameCanvas;
    public GameObject sceneCamera;

    public int playersLeft;

    // Other variables and methods

    private float[,] positions =
    {
        {18,34 },
        {32,-10 },
        {7,-40 },
        {-20,-33 },
        {-66,-7 },
        {-53,24 },
        {37,-58 },
        {-12,-75 },
        {-70,-70 }
    };

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
        //float randomX = Random.Range(-30f, 30f);
        //float randomY = Random.Range(-30f, 30f);
        int idx = Random.Range(0, positions.Length / 2);
        Debug.Log("position length: " + positions.Length/2);
        Debug.Log("random index: " + idx);
        float randomX = positions[idx, 0];
        float randomY = positions[idx, 1];
        PhotonNetwork.Instantiate(playerPrefab.name,
            new Vector2(this.transform.position.x + randomX, this.transform.position.y + randomY),
            Quaternion.identity,
            0);
        Debug.Log(new Vector2(randomX,randomY));
    }
}
