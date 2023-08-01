using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shutdown : MonoBehaviour
{
    public GameObject warningsContainer;
    public GameObject shutdownCoversContainer;
    private List<int> shutdownOrder = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<GameObject> warnings = new List<GameObject> { };
    private List<GameObject> shutdownCovers = new List<GameObject> { };
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            warnings.Add(warningsContainer.transform.GetChild(i).gameObject);
            shutdownCovers.Add(shutdownCoversContainer.transform.GetChild(i).gameObject);
        }
        var shuffledOrder = shutdownOrder.OrderBy(a => Guid.NewGuid()).ToList();
        Debug.Log(shuffledOrder);
        for (int i = 1; i <= 9; i++)
        {
            StartCoroutine(StartWarning(shuffledOrder[i], i));
        }
    }

    private IEnumerator StartWarning(int number, int timeMultiplier)
    {
        yield return new WaitForSeconds(timeMultiplier * 10f);
        // number is 1-based, while idx of warnings and shutdownCovers is 0-based
        Debug.Log(string.Format("region {0} is going to be shut down", number));
        warnings[number - 1].SetActive(true);
        StartCoroutine(ShutdownRegion(number));
    }

    private IEnumerator ShutdownRegion(int number)
    {
        yield return new WaitForSeconds(5f);
        // number is 1-based, while idx of warnings and shutdownCovers is 0-based
        Debug.Log(string.Format("region {0} is shut down", number));
        shutdownCovers[number - 1].SetActive(true);
    }
}
