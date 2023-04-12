using UnityEngine;

	public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;
		public bool IsDontDestroyOnLoad = false;
		public bool IsInitialized { get { return _instance; } }
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					MonoBehaviour[] instances = FindObjectsOfType<T>();

					if (instances.Length > 0)
					{
						return (T)instances[0];
					}

					if (instances.Length > 1)
					{
						Debug.LogError("[Singleton] Singleton classes count more one!");
						return _instance;
					}

					if (_instance == null)
					{
						return _instance = new GameObject("[SINGLETON]", typeof(T)).GetComponent<T>();
					}
				}
				return _instance;
			}
			set
			{
				if (_instance == null) _instance = value;
			}
		}

		public virtual void Awake()
		{
			if (_instance == null)
			{
				_instance = this as T;
				if (IsDontDestroyOnLoad) DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}


