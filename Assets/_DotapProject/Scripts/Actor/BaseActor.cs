using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Du3Project
{
    public class BaseActor : MonoBehaviour
    {
        public int ActorTableID = -1;
        public List<int> ActorAttackTableIDArray = new List<int>();



        public E_Camp MyCamp = E_Camp.Max;




        [SerializeField, ShowOnly]
        protected ActorData m_ActorData = null;// new ActorData();
        public ActorData ActorDataCom
        {
            get { return m_ActorData; }
            protected set { m_ActorData = value;}
        }

        
        
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

        bool m_ISInit = false;
        public void InitSettingData( int p_id, E_Camp p_camp )
        {
            ActorTableID = p_id;
            MyCamp = p_camp;


            m_ActorData = ActorTableData.GetI.GetActorTableData(ActorTableID);
            this.gameObject.layer = CalcManager.GetCampTypeTOLayerIndex(this);

            //m_AnimationCallFN.Clear();
            //m_AnimationCallFN.Add(E_AniCallType.Attack01, Attack1);
            //m_AnimationCallFN.Add(E_AniCallType.Attack01, Attack1);
            m_AnimationCallFNArray = new Action<E_AniCallType>[(int)E_AniCallType.Max];
            m_AnimationCallFNArray[(int)E_AniCallType.Attack01] = Attack1;
            m_AnimationCallFNArray[(int)E_AniCallType.Attack02] = Attack1;


            m_LinkAnimator = GetComponentInChildren<Animator>();

            AttackRange.InitCollisionDetating(this, AttackCollistionEnter);
            SerchingRange.InitCollisionDetating(this, SerchingCollsionEnter);

            ActorAniEventCom.SetAnimationCallBackFN(ActorAttackEventCallFN, ActorAttackAniEventCallFN);


            // 공격 정보 얻기
            AttackDataArray.Clear();
            AttackData tempattackdata = AttackTableData.GetI.GetAttackDataID(1000);
            AttackDataArray.Add(tempattackdata);


            SetDataSetting();

            m_ISInit = true;
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

                if( length <= 3f)
                {
                    movespeed = 0f;
                    return;
                }
            }

            //transform.Translate(movespeed, 0f, 0f);
            transform.position = transform.position + new Vector3(movespeed, 0f, 0f);
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
                UpdateSerchingDieActor();

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
                int randindex = Random.Range(0, 1);
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
                this.gameObject.SetActive(false);

            }


        }


        [SerializeField, ShowOnly]
        protected BaseActor m_TargetActor = null;
        void AttackCollistionEnter(BaseActor p_actor)
        {
            Debug.LogFormat("공격범위 녀석 : {0}, {1}", this.name
                , p_actor.name);

            if(m_TargetActor == null)
            {
                m_TargetActor = p_actor;
            }


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

        public SpriteRenderer m_LinkActorSpirte = null;



        protected void ActorAttackEventCallFN( E_AnimationType p_value )
        {
            Debug.LogFormat("공격 애네미이션 콜 : {0}", p_value);
        }

        //protected Dictionary<E_AniCallType, Action<E_AniCallType>> m_AnimationCallFN = new Dictionary<E_AniCallType, Action<E_AniCallType>>();
        protected Action<E_AniCallType>[] m_AnimationCallFNArray = new Action<E_AniCallType>[(int)E_AniCallType.Max];

        protected void ActorAttackAniEventCallFN( E_AniCallType p_value)
        {
            Debug.LogFormat("애네미이션 콜 : {0}", p_value);
            if( m_AnimationCallFNArray[(int)p_value] != null )
            {
                m_AnimationCallFNArray[(int)p_value]( p_value );
            }
            
        }



        void SetDataSetting()
        {
            m_LinkActorSpirte.sprite = m_ActorData.ActorSpriteImage;

            if(MyCamp == E_Camp.MyCamp)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (MyCamp == E_Camp.EnemyCamp)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

        }

        private void Awake()
        {
            
        }

        void Start()
		{
			
		}

		void Update()
		{
            if(!m_ISInit)
            {
                return;
            }



            UpdateMove();
            UdateAttack();

        }



        public List<AttackData> AttackDataArray = new List<AttackData>();
        public void Attack1(E_AniCallType p_calltype)
        {
            AttackData attackdata = AttackDataArray[0];

            if( attackdata.AttackRangeType == E_AttackRangeType.Meel )
            {
                if(attackdata.AttackMutiType == E_AttackMultiType.Single )
                {
                    float attackval = m_ActorData.Attack + attackdata.AddAttackVal;
                    m_TargetActor.SetDamage(this, attackval);
                }
                else if(attackdata.AttackMutiType == E_AttackMultiType.Multi)
                {
                    float attackval = m_ActorData.Attack + attackdata.AddAttackVal;
                    m_TargetActor.SetDamage(this, attackval);


                    int layermaskval = CalcManager.GetActorCampTypeTOLayerMask(m_TargetActor);
                    Collider[] colliderarray = Physics.OverlapSphere(m_TargetActor.transform.position
                        , attackdata.MultiAttackRangeVal
                        , layermaskval );

                    attackval = attackval * attackdata.MultiAttackRangeDiv;
                    foreach (var item in colliderarray)
                    {
                        BaseActor tempactor = item.GetComponent<BaseActor>();
                        if(tempactor )
                        {
                            tempactor.SetDamage(this, attackval);
                        }
                    }


                }
            }
            else if(attackdata.AttackRangeType == E_AttackRangeType.Range)
            {
                // 피사체 던지기
                InGameBattleManager.GetI.AddRangeAttackObject( m_TargetActor, this, attackdata );

            }


            UpdateSerchingDieActor();

        }

        void UpdateSerchingDieActor()
        {
            if (m_TargetActor.ISDie)
            {
                int layermaskval = CalcManager.GetActorCampTypeTOLayerMask(m_TargetActor);
                Collider[] colliderarray = Physics.OverlapSphere(this.transform.position
                    , AttackRange.SphereRadius + 10f
                    , layermaskval);


                m_TargetActor = null;
                float minlength = float.MaxValue;
                foreach (var item in colliderarray)
                {
                    BaseActor tempactor = item.GetComponent<BaseActor>();

                    if (tempactor != null)
                    {
                        float val = (tempactor.transform.position - this.transform.position).magnitude;
                        if (minlength > val)
                        {
                            m_TargetActor = tempactor;
                        }
                    }
                }

            }
        }

        public void Attack2(E_AniCallType p_calltype)
        {

        }

#if UNITY_EDITOR

        public Color LineColor = Color.red;
        private void OnDrawGizmos()
        {
            if(m_TargetActor == null)
                return;

            Color tempcolor = Gizmos.color;

            Gizmos.color = LineColor;

            Vector3 thispos = this.transform.position;
            thispos.y = 0.5f;
            Gizmos.DrawLine(thispos, m_TargetActor.transform.position);

            Gizmos.color = tempcolor;
        }

#endif


    }

}