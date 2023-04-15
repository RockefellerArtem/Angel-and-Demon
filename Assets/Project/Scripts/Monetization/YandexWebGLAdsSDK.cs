using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public class YandexWebGLAdsSDK : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void ShowFullscreenAd();
    [DllImport("__Internal")] private static extern int ShowRewardedAd(string placement);
    [DllImport("__Internal")] private static extern void GerReward();
    [DllImport("__Internal")] private static extern void AuthenticateUser();
    [DllImport("__Internal")] private static extern void InitPurchases();
    [DllImport("__Internal")] private static extern void Purchase(string id);
    [DllImport("__Internal")] private static extern void CanReviewGame();
    [DllImport("__Internal")] private static extern void SetLeaderboard(string name, int count, string description);
    [DllImport("__Internal")] private static extern void GetLeaderboard(string name);
    [DllImport("__Internal")] private static extern void GetLeaderboards(string name, int count);
    [DllImport("__Internal")] private static extern void OpenWindow(string url);
    [DllImport("__Internal")] private static extern void GetInfoDeviceType();
    [DllImport("__Internal")] private static extern void GetCurrentLanguageToDomen();

    [DllImport("__Internal")] private static extern void SaveData(string data);
    [DllImport("__Internal")] private static extern void LoadData();



    public event Action onInterstitialShown;
    public event Action<string> onInterstitialFailed;
    public event Action<int> onRewardedAdOpened;
    public event Action<string> onRewardedAdReward;
    public event Action<int> onRewardedAdClosed;
    public event Action<string> onRewardedAdError;

    public event Action<string> onDataLeaderboardScorePlayerEntry;
    public event Action<string> onDataLeaderboardsScoreTop;

    public event Action onAuth;
    public event Action<string> onDeviceInfo;
    public event Action<string> onRateUsReason;
    public event Action<string> onPurchaseComplet;
    public event Action onPurchaseError;

    public event Action<string> onLoadData;

    public Queue<int> rewardedAdPlacementsAsInt = new Queue<int>();
    public Queue<string> rewardedAdsPlacements = new Queue<string>();

    [SerializeField] private GameObject _testInterstitialObject;

    public void LoadDataTest(Action<string> callback)
	{
        onLoadData += callback;
        LoadData();
    }

    public void OnLoadData(string data)
	{
        onLoadData(data);
    }

    public void OpenURL(string url)
	{
        OpenWindow(url);
    }

    public void BuyPurchase(string id)
	{
        Purchase(id);
    }

    public void GetInfoDevice()
	{
        GetInfoDeviceType();
    }

    public void GetLanguage()
	{
        GetCurrentLanguageToDomen();
    }
    
    public void OnDeviceInfo(string device)
	{
        onDeviceInfo?.Invoke(device);
	}
    public void Auth()
	{
        AuthenticateUser();
        InitPurchases();
    }

    public void OnPurchaseComplet(string id)
	{
        onPurchaseComplet?.Invoke(id);
    }

    public void OnPurchaseFailed()
	{
        onPurchaseError?.Invoke();
    }



    public void SetLeaderboardScore(string name, int score, string description)
	{
        SetLeaderboard(name, score, description);
	}

    public void GetLeaderboardScorePlayerEntry(string name)
    {
        GetLeaderboard(name);
    }

    public void GetLeaderboardsScoreTop(string name, int countTopPlayers)
    {
        GetLeaderboards(name, countTopPlayers);
    }

    public void OnLeaderboardsScoreTop(string data)
	{
        onDataLeaderboardsScoreTop(data);

    }

    public void OnLeaderboardScorePlayerEntry(string data)
    {
        onDataLeaderboardScorePlayerEntry(data);
    }

    public void ShowInterstitial() 
    {
#if UNITY_ANDROID
        _testInterstitialObject.SetActive(true);
#elif UNITY_EDITOR
        _testInterstitialObject.SetActive(true);
#else
         ShowFullscreenAd();
#endif

    }

    public void Review()
	{
        CanReviewGame();
    }

    public void RateUsStatus(string feedbackSent)
	{
        if(feedbackSent == "true")
		{
            onRateUsReason?.Invoke("TRUE");
        }
		else
		{
            onRateUsReason?.Invoke("FALSE");
        }
       
    }


    public void RateUsError(string reason)
	{
        onRateUsReason?.Invoke(reason);
	}

    public void ShowRewarded(string placement) 
    {
        GetComponent<AdsController>().IsTimerADS = false;
        rewardedAdPlacementsAsInt.Enqueue(ShowRewardedAd(placement));
        rewardedAdsPlacements.Enqueue(placement);
    }
 
    public void OnInterstitialShown() 
    {
        onInterstitialShown();
    }

    public void OnInterstitialError(string error) 
    {
        onInterstitialFailed(error);
    }

    public void OnRewardedOpen(int placement) 
    {
        onRewardedAdOpened(placement);
    }

    public void OnRewarded(int placement) 
    {
        if (placement == rewardedAdPlacementsAsInt.Dequeue()) 
        {
            onRewardedAdReward.Invoke(rewardedAdsPlacements.Dequeue());
        }
    }

    public void OnRewardedClose(int placement) 
    {
        GetComponent<AdsController>().IsTimerADS = false;
        onRewardedAdClosed(placement);
    }

    public void OnRewardedError(string placement) 
    {
        onRewardedAdError(placement);
        rewardedAdsPlacements.Clear();
        rewardedAdPlacementsAsInt.Clear();
    }

}
