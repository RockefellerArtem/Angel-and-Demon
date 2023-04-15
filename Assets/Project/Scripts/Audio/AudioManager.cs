using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioManager : SingletonMono<AudioManager>
{
		[Header("Audio Sources:")]
		[SerializeField] private AudioSource _musicSource;
		// n[SerializeField] private AudioSource _soundSource;

		[Space]

		[Header("Audios:")]
		//[SerializeField] private List<Audio> _sounds = new List<Audio>();
		[SerializeField] private List<Audio> _musics = new List<Audio>();
		
		[SerializeField] private List<SoundButtonHolder> _iconsFromSoundButton;

		private Dictionary<SoundsType, Audio> _audios = new Dictionary<SoundsType, Audio>();
		
		private bool _isStatus = true;
		public bool IsMute { get; private set; }

		public override void Awake()
		{
			base.Awake();
			
			_isStatus = Convert.ToBoolean(PlayerPrefs.GetInt("music", 1));
			
			for (int i = 0; i < _iconsFromSoundButton.Count; i++)
			{
				_iconsFromSoundButton[i].OnClickSoundButton += OnClickSound;
			}

			//_sounds.ForEach(sound => _audios.Add(sound.Type, sound));
			_musics.ForEach(music => _audios.Add(music.Type, music));
			
			SetMusicAndSound();
			
			UpdateStatusIcon();
		}
		
		private void SetMusicAndSound()
		{
			PlayMusic(SoundsType.MusicMainMenu, _isStatus);
			MuteMusic(_isStatus);
			//MuteSound(_isStatus);
		}

		private void UpdateStatusIcon()
		{
			for (int i = 0; i < _iconsFromSoundButton.Count; i++)
			{
				_iconsFromSoundButton[i].SetIcon(_isStatus);
			}
		}

		private void OnClickSound()
		{
			_isStatus = !_isStatus;
			UpdateStatusIcon();
			SetMusicAndSound();
			PlayerPrefs.SetInt("music", Convert.ToInt32(_isStatus));
		}

		//public void PlaySound(SoundsType typeAudio)
		//{
		//	var audio = GetAudioFromTargetType(typeAudio);
		//
		//	_soundSource.PlayOneShot(audio.Clip);
		//	
		//}

		public void MuteMusic(bool isMute)
		{
			_musicSource.DOFade(isMute ? 1 : 0, 0.5f);
			IsMute = isMute;
		}

		//public void MuteSound(bool isMute)
		//{
		//	_soundSource.DOFade(isMute ? 1 : 0, 0.5f);
		//}

		public void PlayMusic(SoundsType typeAudio, bool isPlay)
		{
			var audio = GetAudioFromTargetType(typeAudio);
			if (isPlay)
			{
				_musicSource.Play();
			}
			else
			{
				_musicSource.Stop();
				return;
			}

			if(_musicSource.isPlaying)
			{
				_musicSource.clip = audio.Clip;
				_musicSource.Play();

				return;
			}

			_musicSource.clip = audio.Clip;
			_musicSource.Play();
		}	
		
		private Audio GetAudioFromTargetType(SoundsType typeAudio)
		{ 
			if(_audios.ContainsKey(typeAudio) == false)
			{
				Debug.LogError("You are trying to use a type audio that is not on the list!");
				return null;
			}

			Audio audio = _audios[typeAudio];

			return audio;
		}
}


[Serializable]
public class Audio
{
	[SerializeField] private SoundsType _typeAudio;
	[SerializeField] private AudioClip _audioClip;

	public SoundsType Type => _typeAudio;
	public AudioClip Clip => _audioClip;
}


