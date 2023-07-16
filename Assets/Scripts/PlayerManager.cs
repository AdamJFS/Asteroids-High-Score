using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    

    public Leaderboard leaderboard;
    public TMP_InputField playerNameInputField;

  

    [System.Obsolete]
    void Start()
    {
        
        StartCoroutine(SetupRoutine());
    }


    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Succesfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name" + response.Error);
            }
        });
    }



    [System.Obsolete]
    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true; 
            }
            else
            {
                Debug.Log("Could not satrt session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

}
