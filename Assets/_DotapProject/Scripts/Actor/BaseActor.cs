using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Du3Project
{
    public class BaseActor : MonoBehaviour
    {
        [SerializeField]
        protected ActorData m_ActorData = new ActorData();
        public ActorData ActorDataCom
        {
            get { return m_ActorData; }
            protected set { m_ActorData = value;}
        }

        public E_Camp MyCamp = E_Camp.Max;
        
        public bool ISDie
        {
            get { return m_ActorData.HP <= 0;  }

        }

        public float ActorAttackVal
        {
            get
            {
                return m_ActorData.Attack;
            }
        }



        protected void UpdateMove()
        {
            float movespeed = m_ActorData.MoveSpeed;
            if( MyCamp == E_Camp.MyCamp )
            {
                // 왼쪽에서 오른쪽
                movespeed = movespeed * Time.deltaTime;
                //transform.Translate(m_ActorData.MoveSpeed * Time.deltaTime, 0f, 0f);

            }
            else if(MyCamp == E_Camp.EnemyCamp)
            {
                // 오른쪽에서 왼쪽
                //transform.Translate(m_ActorData.MoveSpeed * Time.deltaTime, 0f, 0f);
                movespeed = movespeed * -Time.deltaTime;
            }
            else
            {
                //
                Debug.LogErrorFormat("에러임 확인 해야지됨 : {0}", this.name);
                return;
            }

            if( m_TargetActor != null )
            {
                Vector3 vector = m_TargetActor.transform.position - transform.position;
                float length = vector.magnitude;

                if( length <= 0.5f)
                {
                    movespeed = 0f;
                    return;
                }
            }

            transform.Translate(movespeed, 0f, 0f);
        }


        float m_NextAttackSec = 0f;
        public void UdateAttack()
        {
            if(m_TargetActor == null)
            {
                return;
            }

            if (m_TargetActor.ISDie )
            {
                return;
            }


            bool isattack = false;
            if(m_NextAttackSec <= Time.time)
            {
                m_NextAttackSec += m_ActorData.AttackSpeed;
                isattack = true;
            }


            if( isattack )
            {
                //m_TargetActor.SetDamage( this, this.ActorAttackVal );

                int randindex = Random.Range(0, 2);
                E_RandomAttackType val = (E_RandomAttackType)Random.Range(0, (int)E_RandomAttackType.Max);
                m_LinkAnimator.SetTrigger( val.ToString() );

                Debug.LogFormat("공격 : {0}, {1}, {2} ", val, this.name, m_TargetActor.name);
                

            }

        }

        public void SetDamage( BaseActor p_attacker, float p_attackval )
        {
            if( p_attacker.ISDie )
            {
                // 

            }

            m_ActorData.HP = (int)((float)m_ActorData.HP - p_attackval);


            if(m_ActorData.HP <= 0)
            {
                m_ActorData.HP = 0;


            }


        }


        protected BaseActor m_TargetActor = null;
        void AttackCollistionEnter(BaseActor p_actor)
        {
            Debug.LogFormat("공격범위 녀석 : {0}, {1}", this.name
                , p_actor.name);

            m_TargetActor = p_actor;
        }

        void SerchingCollsionEnter(BaseActor p_actor)
        {
            Debug.LogFormat("서칭 범위 녀석 : {0}, {1}", this.name
                , p_actor.name);
        }



        [Header("[내부 사용하기위한 변수들]")]
        public CollisionDetaing AttackRange = null;
        public CollisionDetaing SerchingRange = null;
        public ActorAniEvent_Com ActorAniEventCom = null;

        [SerializeField, ShowOnly ]
        protected Animator m_LinkAnimator = null;



        protected void ActorAttackEventCallFN( E_AnimationType p_value )
        {
            Debug.LogFormat("공격 애네미이션 콜 : {0}", p_value);
        }

        protected void ActorAttackAniEventCallFN( E_AniCallType p_value)
        {
            Debug.LogFormat("애네미이션 콜 : {0}", p_value);
        }



        private void Awake()
        {
            m_LinkAnimator = GetComponentInChildren<Animator>();

            AttackRange.InitCollisionDetating(this, AttackCollistionEnter);
            SerchingRange.InitCollisionDetating(this, SerchingCollsionEnter);

            ActorAniEventCom.SetAnimationCallBackFN(ActorAttackEventCallFN, ActorAttackAniEventCallFN);


        }

        void Start()
		{
			
		}

		void Update()
		{
            UpdateMove();
            UdateAttack();

        }
	}

}