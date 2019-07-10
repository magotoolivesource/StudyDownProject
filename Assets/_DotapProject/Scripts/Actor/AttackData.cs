using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
    //[System.Serializable]
    [CreateAssetMenu(fileName = "AttackData", menuName = "_Dotap/CreateAttackData", order = 1)]
    public class AttackData : ScriptableObject
	{
        public int AttackID = -1;
        public E_AttackRangeType AttackRangeType = E_AttackRangeType.Meel;
        public E_AttackMultiType AttackMutiType = E_AttackMultiType.Single;

        public float AddAttackVal = 1f; // 기본공격력에 +하기
        public float MultiAttackRangeVal = 1f; // 멀티모드시 범위값
        public float MultiAttackRangeDiv = 1f; // 멀티로 공격시 비율값


        // 레인지일시 사용되는 변수
        public float RangeSpeedSec = float.MaxValue - 100f; // 0 이하면 즉시 시전 1 1초안에 도착
        public Sprite RangeSprite = null;

    }

}