using UnityEngine;
using System.Collections;

//public class SingletonTample : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}



public class SingletonTample<T> where T : class, new()
{
	protected static T instance = null;

	/**
      Returns the instance of this singleton.
   */
	public static T GetI
	{
		get
		{
			if(instance == null)
			{
				instance = new T();
				if (instance == null)
				{
					Debug.LogError("An instance of " + typeof(T) + 
					               " is needed in the scene, but there is none.");
				}
			}
			
			return instance;
		}
	}


	// 초기화구현용.
	public virtual void SingletoneInit(){}


	#region 싱글톤 생성및 지우는것 

    public static void DestroyInstance()
    {
        if (instance != null)
        {
            instance = null;
        }
    }

//
//	public static T CreateInstance()
//	{
//		if(instance == null)
//		{
//			instance = (T) FindObjectOfType(typeof(T));
//			
//			if (instance == null)
//			{
//				Debug.LogError("An instance of " + typeof(T) + 
//				               " is needed in the scene, but there is none.");
//			}
//		}
//		else
//		{
//			Debug.LogError(" Twice Create SingleTon " + typeof(T) + 
//			               " is needed in the scene, but there is none.");
//		}
//		
//		return instance;
//	}

	#endregion 싱글톤 생성및 지우는것 

}

