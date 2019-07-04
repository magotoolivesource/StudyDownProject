//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;



//public class ActorLinkAnimator_Com : MonoBehaviour 
//{
//    public BaseActor_Com LinkActorCom = null;


//    public Animator ActorAnimator = null;

//    [SerializeField, ShowOnly]
//    protected E_AnimationType m_CurrAnimationType = E_AnimationType.Max;


//    public ActorAniEvent_Com LinkAniEventCom = null;




//    [SerializeField, ShowOnly]
//    protected E_AnimationType m_CurrentAnimationType = E_AnimationType.Max;
//    public void SetDirectAnimation(E_AnimationType p_anitype)
//    {
        
//    }
//    public void SetAnimationTrigger( E_AnimationType p_anitype )
//    {
//        if (m_CurrAnimationType == p_anitype)
//        {
//            return;
//        }

//        ActorAnimator.SetTrigger(p_anitype.ToString());

//    }

//    protected void _Call_AnimationEvent(E_AnimationType p_type)
//    {
//        Debug.LogFormat("_Call_AnimationEvent : {0}", p_type);



//    }

//    protected void _Call_EXAnimationEvent(E_AniCallType p_type)
//    {
////         Debug.LogFormat("_Call_EXAnimationEvent : {0}, {1}"
////             , this.name
////             , p_type );




//        switch (p_type)
//        {
//            case E_AniCallType.Event:
//                break;
//            case E_AniCallType.Sound:
//                break;
//            case E_AniCallType.WalkLeft_Sound:
//                break;
//            case E_AniCallType.WalkRight_Sound:
//                break;
//            case E_AniCallType.ATK0Start:
//                GetAttackWeightVal(E_AniCallType.ATK0Start);
//                break;
//            case E_AniCallType.ATK0Sound:
//                break;
//            case E_AniCallType.ATK0Hit:
//                LinkActorCom.SetAttackHitEvent(E_AnimationType.Attack0);
//                break;
//            case E_AniCallType.ATK0End:
//                SetAnimationSpeed(1f);
//                break;
//            case E_AniCallType.ATK0Effect:
//                break;
//            case E_AniCallType.ATK1Start:
//                GetAttackWeightVal(E_AniCallType.ATK1Start);
//                break;
//            case E_AniCallType.ATK1Sound:
//                break;
//            case E_AniCallType.ATK1Hit:
//                LinkActorCom.SetAttackHitEvent(E_AnimationType.Attack1);
//                break;
//            case E_AniCallType.ATK1End:
//                break;
//            case E_AniCallType.ATK1Effect:
//                break;
//            case E_AniCallType.ATK2Start:
//                GetAttackWeightVal(E_AniCallType.ATK2Start);
//                break;
//            case E_AniCallType.ATK2Sound:
//                break;
//            case E_AniCallType.ATK2Hit:
//                LinkActorCom.SetAttackHitEvent(E_AnimationType.Attack2);
//                break;
//            case E_AniCallType.ATK2End:
//                break;
//            case E_AniCallType.ATK2Effect:
//                break;
//            case E_AniCallType.DIEStart:
//                break;
//            case E_AniCallType.DIESound:
//                break;
//            case E_AniCallType.DIEEffect:
//                break;
//            case E_AniCallType.DIE_End:
//                LinkActorCom.SetDieEndEvent();
//                break;
//            case E_AniCallType.IDLE_Start:
//                break;
//            case E_AniCallType.DAMAGESound:
//                break;
//            case E_AniCallType.DAMAGEEffect:
//                break;
//            case E_AniCallType.End:
//                break;
//            case E_AniCallType.Max:
//                break;
//            default:
//                break;
//        }


//    }


//    public void GetAttackWeightVal( E_AniCallType p_atktype )
//    {
//        float atkspeed = LinkActorCom.TotalAttackSpeed;
//        SetAnimationSpeed(atkspeed);
//    }
//    public void SetAnimationSpeed(float p_val)
//    {
//        // 기본 애니메이션은 20fps로 만들어져 있음 1초가 20fps임

//        float tempspeed = 1 / p_val;

//        ActorAnimator.speed = tempspeed;

//    }


//    [ContextMenu("[테스트_레이어]")]
//    void Editor_GetAniPackName()
//    {
//        int layerindex = ActorAnimator.GetLayerIndex("Base Layer");
//        int layerindex2 = ActorAnimator.GetLayerIndex("Base Layer2");

//        AnimatorClipInfo[] clipinfo = ActorAnimator.GetNextAnimatorClipInfo(layerindex);
//        //AnimationInfo[] clipinfo2 = ActorAnimator.GetCurrentAnimationClipState(layerindex);


//        int taghashval = Animator.StringToHash("Attack0");

//        AnimatorStateInfo stateinfo = ActorAnimator.GetCurrentAnimatorStateInfo(layerindex);





//        int count = clipinfo.Length;
//        for (int i=0; i< count; ++i)
//        {
//        	Debug.LogFormat("ClipInfo Ani : {0}, {1}, {2}"
//                , clipinfo[i].clip.name
//                , clipinfo[i].clip.frameRate
//                , clipinfo[i].clip.length
//                );
//        }


//#if UNITY_EDITOR

//        UnityEditor.Animations.AnimatorController ac = ActorAnimator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
//        count = ac.layers.Length;

//        for (int i = 0; i < count; ++i)
//        {
//            Debug.LogFormat("Layer : {0}, {1}", i, ac.layers[i].name);

//        }

//#endif

//        // 순환하지 않고 찾아내는 방법 좀 생각해야지 될듯함
//        // 순환해서 찾는것이 안좋을것 같음 
//        // 애니메이션 클립찾아내는 방식임
//        RuntimeAnimatorController ac2 = ActorAnimator.runtimeAnimatorController;
//        count = ac2.animationClips.Length;
//        for (int i = 0; i < count; ++i)
//        {
//            Debug.LogFormat("AniClip Name : {0}, {1}, {2}, {3} "
//                , ac2.animationClips[i].name
//                , ac2.animationClips[i].isLooping
//                , ac2.animationClips[i].frameRate
//                , ac2.animationClips[i].length
//                );

//        }

////         UnityEngine.AnimationClip clipaa = null;
////         ac2.animationClips[0].AddEvent

//    }

//    bool m_ISInit = false;
//    public void InitSettingActorAniCom( BaseActor_Com p_actorcom
//        , bool p_directinit = false )
//    {
//        if( !p_directinit && m_ISInit )
//        {
//            return;
//        }

//        //p_actorcom
//        LinkActorCom = p_actorcom;
//        LinkAniEventCom.SetAnimationCallBackFN(_Call_AnimationEvent, _Call_EXAnimationEvent);

//        SetSpriteSettingNAnimation();

//        m_ISInit = true;
//    }

//    protected void SetSpriteSettingNAnimation()
//    {
//        ActorAnimator.runtimeAnimatorController = LinkActorCom.BaseActorTableData.ActorAnimatorController;
        
//    }


//    public void InitSettingActorAniCom()
//    {
//        LinkAniEventCom.SetAnimationCallBackFN(_Call_AnimationEvent, _Call_EXAnimationEvent);

//        m_ISInit = true;
//    }



//	void Start () 
//    {
		
//	}
	
	
//}
