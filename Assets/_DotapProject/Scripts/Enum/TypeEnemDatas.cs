using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
    public enum E_Camp
    {
        MyCamp,
        EnemyCamp,
        //NPCCamp,

        Max
    }


    public enum E_RandomAttackType
    {
        Attack01 = 1,
        Attack02,

        Max
    }

    public enum E_AnimationType
    {
        None = 0,
        Attack,

        Max
    }

    public enum E_AniCallType
    {
        None = 0,
        Attack01,
        Attack02,

        Max
    }

    public enum E_AttackAttributeType
    {
        Default = 0,
        Archer,
        Mage,
        Sige,

        Max
    }

    // 피사체가 있냐 공격 관련 타입
    public enum E_AttackRangeType
    {
        Meel = 0, // 다이렉트 공격
        Range, // 시간딜레이 공격

        Max
    }

    public enum E_AttackMultiType
    {
        Single = 0,
        Multi,

        Max
    }





}