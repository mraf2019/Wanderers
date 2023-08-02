using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameCanvas;
    public GameObject sceneCamera;

    public int playersLeft;
    public GameObject[] loots = new GameObject[15];

    // Other variables and methods

    private float[,] positions = Constanat.positions;

    private Vector3[] LootPos = Constanat.LootPos;

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
        StartCoroutine("RefreshResource");
    }

    public void PlayerDestroyed()
    {
        playersLeft--;

        if (playersLeft <= 1)
            EndGame();
    }

    public void EndGame()
    {
        int playerRemain = PhotonNetwork.playerList.Length;
        PlayerPrefs.SetInt("rank", playerRemain);
        if (PhotonNetwork.isMasterClient)
        {
            //todo: transfer masterClient position
        }
        PhotonNetwork.Disconnect();
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
        //float randomX = positions[idx, 0];
        //float randomY = positions[idx, 1];
        float randomX = 38;
        float randomY = -84;
        PhotonNetwork.Instantiate(playerPrefab.name,
            new Vector2(this.transform.position.x + randomX, this.transform.position.y + randomY),
            Quaternion.identity,
            0);
        Debug.Log(new Vector2(randomX,randomY));
        sceneCamera.SetActive(true);
    }

    IEnumerator RefreshResource()
    {
        while (true)
        {
            if (PhotonNetwork.isMasterClient)
            {
                foreach (GameObject loot in loots)
                {
                    if (loot != null)
                    {
                        Destroy(loot.gameObject);
                    }
                }
                Debug.Log("all loot destroyed");
                for (int i = 0; i < LootPos.Length; i++)
                {
                    loots[i] = PhotonNetwork.InstantiateSceneObject("loot", LootPos[i], Quaternion.identity, 0, null);
                }
                Debug.Log("loots generated");
            }
            yield return new WaitForSeconds(Constanat.refreshInterval);
        }
    }
}
