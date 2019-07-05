using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
    [System.Serializable]
	public class AttackData
	{
        public E_AttackRangeType AttackRangeType = E_AttackRangeType.Meel;
        public E_AttackMultiType AttackMutiType = E_AttackMultiType.Single;

        public float AddAttackVal = 1f; // 기본공격력에 +하기

        public float MultiAttackRangeVal = 1f; // 멀티모드시 범위값

        public float MultiAttackRangeDiv = 1f; // 멀티로 공격시 비율값
    }

}