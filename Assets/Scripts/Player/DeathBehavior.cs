using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class DeathBehavior : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private GameObject popup;
    private string game_id = "4917017";

    private GameObject collisionObject;

    [SerializeField] private int AllowedAdRequests = 3;

    private void Start()
    {
        popup.SetActive(false);
        Advertisement.Initialize(game_id, true, this);
    }

    private GameObject findChildOfPopup(string name)
    {
        for (int i = 0; i < popup.transform.childCount; i++)
        {
            if (popup.transform.GetChild(i).name == name)
                return popup.transform.GetChild(i).gameObject;
        }
        return null;
    }

    public void die(GameObject? collisionObject)
    {
        if (collisionObject != null)
            this.collisionObject = collisionObject;

        ScoreManager.saveScore();
        //TODO: Play Sound

        Time.timeScale = 0;
        PlayerAudioManager.muteAudio();

        //open popup
        popup.SetActive(true);
        if (AllowedAdRequests > 0)
            findChildOfPopup("Watch Ad Button").SetActive(true);
        else
            findChildOfPopup("Watch Ad Button").SetActive(false);

    }

    public void replayButton()
    {
        Time.timeScale = 1;
        CoinManager.AddCoinsToTotal();
        SceneManager.LoadScene(0);
    }

    public void adButton()
    {
        if (!Advertisement.isInitialized)
            return;
        if (AllowedAdRequests > 0)
            Advertisement.Show("Rewarded_Android", this);
        else this.replayButton();

    }

    #region ads interface methods


    public void OnInitializationComplete()
    {
        Debug.Log("Initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }


    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Start Showing");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals("Rewarded_Android") && UnityAdsShowCompletionState.COMPLETED.Equals(showCompletionState))
        {
            AllowedAdRequests--;

            popup.SetActive(false);
            Destroy(collisionObject);
            Time.timeScale = 1;
            PlayerAudioManager.unmuteAudio();

            //stop rotation of player
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Failed to load: {error.ToString()}");
        //restart the game
        this.replayButton();
    }
    #endregion
}
