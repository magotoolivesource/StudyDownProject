using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationEvent_Com<Tenum, TCall> : MonoBehaviour 
{

    [SerializeField, ShowOnly]
    protected System.Action<Tenum> m_AniCallFN = null;

    [SerializeField, ShowOnly]
    protected System.Action<TCall> m_CallBackFN = null;


    public virtual void _Call_AnimationEvent(Tenum p_type)
    {
        if (m_AniCallFN != null )
        {
            m_AniCallFN(p_type);
        }
    }

    public virtual void _Call_EXAnimationEvent(TCall p_type)
    {
        if (m_CallBackFN != null )
        {
            m_CallBackFN(p_type);
        }

    }


    public virtual void ResetAllDatas()
    {
        if (m_AniCallFN != null)
        {
            m_AniCallFN = null;
        }

        if (m_CallBackFN != null)
        {
            m_CallBackFN = null;
        }
    }

    public virtual void SetAnimationCallBackFN(System.Action<Tenum> p_anifn, System.Action<TCall> p_typecallfn)
    {
        ResetAllDatas();

        m_AniCallFN = p_anifn;
        m_CallBackFN = p_typecallfn;

    }


    protected virtual void Start() 
    {
		
	}
	
	
}
