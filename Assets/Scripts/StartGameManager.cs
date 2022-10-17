using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public void StartGame(float level)
    {
        GameManager.Instance.StartGame(level);
    }
}
