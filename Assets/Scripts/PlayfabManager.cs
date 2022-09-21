using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    public GameObject leaderboardPanel;

    public GameObject openButton;
    public GameObject closeButton;

    public GameObject rowPrefab;
    public Transform rowsParent;

    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams {
                GetPlayerProfile = true
            }
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result) {
        Debug.Log("Successful Login!");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null) {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        if (name == null) {
            UpdatePlayerDisplayName();
        }
    }

    void UpdatePlayerDisplayName() {
        var request = new UpdateUserTitleDisplayNameRequest {
            DisplayName = "Alex"
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result) {
        Debug.Log("Displayname succesfully set");
    }

    void OnError(PlayFabError error) {
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    }

    void SendLeaderBoard() {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Score",
                    Value = gameObject.GetComponent<User>().highScore
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Successful Update");
    }

    void GetLeaderBoard() {
        var request = new GetLeaderboardRequest {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    public void OpenLeaderboard() {
        StartCoroutine(GetSetLeader());
    }

    void OnLeaderboardGet(GetLeaderboardResult result) {

        foreach(Transform item in rowsParent) {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject newRow = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }

    IEnumerator GetSetLeader()
     {
        SendLeaderBoard();
        yield return new WaitForSeconds(2f);
        GetLeaderBoard();
        closeButton.SetActive(true);
        openButton.SetActive(false);
        leaderboardPanel.SetActive(true);
     }

     public void closePanel() {
        openButton.SetActive(true);
        closeButton.SetActive(false);
        leaderboardPanel.SetActive(false);
     }
}
