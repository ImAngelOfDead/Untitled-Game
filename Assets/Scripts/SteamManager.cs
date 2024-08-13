using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
    private static SteamManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(480);
            Debug.Log(Steamworks.SteamClient.IsValid);
            var mySteamId = Steamworks.SteamClient.SteamId;
            Debug.Log($"SteamId: {mySteamId}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error: {e.Message}");
        }
    }
    void Update()
    {
        Steamworks.SteamClient.RunCallbacks();
    }
}
