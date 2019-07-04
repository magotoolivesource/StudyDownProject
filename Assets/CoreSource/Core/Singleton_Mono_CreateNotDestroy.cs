﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_Mono_CreateNotDestroy<T> : MonoBehaviour where T : MonoBehaviour
{

    protected static T instance;

    /**
      Returns the instance of this singleton.
   */
    public static T GetI
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }

            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if ( Application.isPlaying )
                {

                    if (instance == null)
                    {
                        Debug.LogFormat("<color=#ff0000>An instance of {0} </color> is needed in the scene, but there is none.", typeof(T));

                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        instance.name = "(DontSingleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(instance.gameObject);
                        Debug.LogFormat("<color=#ff0000>Add Compoment DontSingleton </color> : {0}  ", instance.name);
                    }
                    else
                    {

                        //                     GameObject singleton = new GameObject();
                        //                     instance = singleton.AddComponent<T>();
                        instance.name = "(DontSingleton) " + typeof(T).ToString();
                        DontDestroyOnLoad(instance.gameObject);

                    }
                }

            }

            return instance;
        }
    }


    private static bool applicationIsQuitting = false;
    protected virtual void SetInitSetting()
    {

    }

    protected virtual void AwakeParent()
    {
        if (instance == null
            || instance.gameObject == this.gameObject)
        {

        }
        else
        {
            //Debug.LogError("Same Manager Destroy : " + this.name);
            Debug.LogFormat("<color=#ffff00>Same Manager Destroy : </color>" + this.name);
            GameObject.Destroy(this.gameObject);
        }

        if (instance != null
            && instance.gameObject == this.gameObject)
        {
            SetInitSetting();
        }

    }

    protected void OnDestroyParent()
    {
        if (instance != null
            && instance.gameObject == this.gameObject)
        {
            Debug.LogFormat("<color=#ff0000>ParentDestroyA : </color>" + this.name);
            Singleton_Mono_CreateNotDestroy<T>.applicationIsQuitting = true;
        }

    }




    #region 싱글톤 생성및 지우는것

    //	public static void DestroyInstance()
    //	{
    //		if(instance)
    //		{
    //			instance = null;
    //		}
    //	}
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
