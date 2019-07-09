using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{

    public enum E_ActorDataName
    {
        선장0 = 0,
        선원1,
        봄버,

        Max
    }


    //[System.Serializable]
    [CreateAssetMenu(fileName = "ActorData", menuName = "_Dotap/CreateActorData", order = 1)]
    public class ActorData : ScriptableObject
	{
        public int ID = -1;
        public E_ActorDataName ActorDataNameEnum = E_ActorDataName.Max;

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

        public Sprite ActorSpriteImage = null;

        public ActorData(ActorData p_clonedata )
        {
            ID = p_clonedata.ID;
            ActorDataNameEnum = p_clonedata.ActorDataNameEnum;
            Name = p_clonedata.Name;
            FullName = p_clonedata.FullName;
            Descript = p_clonedata.Descript;
            ActorImgae = p_clonedata.ActorImgae;
            HP = p_clonedata.HP;
            Attack = p_clonedata.Attack;
            Def = p_clonedata.Def;
            MoveSpeed = p_clonedata.MoveSpeed;
            AttackSpeed = p_clonedata.AttackSpeed;
            ActorSpriteImage = p_clonedata.ActorSpriteImage;
        }

    }

}