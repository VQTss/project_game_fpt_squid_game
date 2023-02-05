using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassGameWin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            FindObjectOfType<LoadScene>().winpanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
