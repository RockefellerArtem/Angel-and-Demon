using System;
using UnityEngine;

public class AdsController : MonoBehaviour
{
	public static AdsController Instance;
	
	[SerializeField] private YandexWebGLAdsSDK _yandexSDK;
	[SerializeField] private float _time;
	[SerializeField] private float _workTime;
	[SerializeField] private bool _isInterstitial = false;
	public bool IsTimerADS = true;
	private bool _isRewardedSuccessful = false;

	private bool _isMutable = false;

	public event Action OnRewarded;
	private void Awake()
	{
		Instance = this;
		_workTime = _time;
		
		_yandexSDK.onRewardedAdClosed += CloseReward;
		_yandexSDK.onRewardedAdOpened += OpenReward;
		_yandexSDK.onRewardedAdReward += SuccessfulReward;
		
	}
	private void OpenReward(int obj)
	{
		if (AudioManager.Instance.IsMute)
		{
			_isMutable = true;
			AudioManager.Instance.MuteMusic(false);
		}
	}
	
	private void CloseReward(int id)
	{
		if (_isRewardedSuccessful)
		{
			OnRewarded?.Invoke();
			OnRewarded = null;
		}

		if (_isMutable)
		{
			_isMutable = false;
			AudioManager.Instance.MuteMusic(true);
		}
	}

	private void Update()
	{
		if (IsTimerADS) Timer();
	}

	private void SuccessfulReward(string rewardable)
	{
		_isRewardedSuccessful = true;
	}
	
	public void ShowInterstitial()
	{
		if (_isInterstitial)
		{
			_isInterstitial = false;
			_yandexSDK.ShowInterstitial();

		}
	}

	public void ShowReward(Action rewardedCallback)
	{
		OnRewarded = rewardedCallback;
		string name = "rewarded";
		_yandexSDK.ShowRewarded(name);
	}

	private void Timer()
	{
		_workTime -= Time.deltaTime;
		if (_workTime <= 0)
		{
			_workTime = _time;
			_isInterstitial = true;
		}
	}
}
