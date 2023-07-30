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

    private float[,] positions =
    {
        {18,34 },
        {32,-10 },
        {-30,10 },
        {-20,-33 },
        {-66,-7 },
        {-53,24 },
        {37,-58 },
        {-12,-75 },
        {-70,-75 }
    };

    private Vector3[] LootPos = new Vector3[15]
    {
        new Vector3(51,37,0),
        new Vector3(19,34,0),
        new Vector3(-13,50,0),
        new Vector3(-46,34,0),
        new Vector3(-58,53,0),
        new Vector3(-46,-3,0),
        new Vector3(-2,15,0),
        new Vector3(19,-10,0),
        new Vector3(51,-14,0),
        new Vector3(41,-43,0),
        new Vector3(55,-62,0),
        new Vector3(-4,-33,0),
        new Vector3(-15,-52,0),
        new Vector3(-41,-39,0),
        new Vector3(-55,-65,0)
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
        StartCoroutine("RefreshResource");
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
                Debug.Log("2 loots generated");
            }
            yield return new WaitForSeconds(15);
        }
    }
}
