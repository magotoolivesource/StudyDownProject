using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "ActorData", menuName = "_Dotap/CreateActorData", order = 1)]
    public class ActorData : ScriptableObject
	{
        public int ID = -1;
        // 액터 이름등 고유값
        public string Name = "";
        public string FullName = "";
        public string Descript = "";
        public string ActorImgae = "";


        // 액터 속성값
        public int HP = 100;
        public float Attack = 1f;
        public float Def = 1f;

        public float MoveSpeed = 1f;

        public float AttackSpeed = 1f;





    }

}