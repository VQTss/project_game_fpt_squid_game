using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    public List<Transform> mode;

    public GameWin count;

    void Start()
    {
        mode = GetChildren(transform);
        foreach (Transform t in mode)
        {
            t.gameObject.SetActive(false);
        }

        int n = Random.Range(0,mode.Count);

        mode[n].gameObject.SetActive(true);

        count.CountPieces();
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> mode = new List<Transform>();

        foreach(Transform child in parent)
        {
            mode.Add(child);
        }

        return mode;
    }
}
