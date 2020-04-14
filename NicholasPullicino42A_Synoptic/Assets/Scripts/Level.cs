using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    void Start()
    {

    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++; // breakableBlocks = breakableBlocks + 1;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--; // breakableBlocks = breakableBlocks - 1;

        if(breakableBlocks <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
