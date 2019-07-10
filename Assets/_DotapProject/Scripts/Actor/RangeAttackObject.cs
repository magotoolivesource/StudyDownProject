using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
	public class RangeAttackObject : MonoBehaviour
	{
        [ShowOnly]
        public AttackData m_LinkAttackData = null;
        [ShowOnly]
        public float m_AttackVal = 10;
        [ShowOnly]
        public float m_MoveSpeed = 1f;
        [ShowOnly]
        public BaseActor m_TargetActor = null; // 피격자
        [ShowOnly]
        public BaseActor m_AttackerActor = null; // 공격자

        public SpriteRenderer m_LinkSprite = null;

        bool m_ISInit = false;
        public void Initlize( BaseActor p_targetActor, BaseActor p_attacker, AttackData p_attackdata )
        {
            if(m_LinkSprite == null)
            {
                m_LinkSprite = GetComponent<SpriteRenderer>();
            }

            m_LinkAttackData = p_attackdata;
            m_TargetActor = p_targetActor;
            m_AttackerActor = p_attacker;

            m_MoveSpeed = m_LinkAttackData.RangeSpeedSec;
            m_LinkSprite.sprite = m_LinkAttackData.RangeSprite;

            if (m_LinkAttackData.RangeSpeedSec >= float.MaxValue - 100)
            {
                SetAttack();
            }
            m_ISInit = true;

            transform.position = p_attacker.transform.position;
        }

        void SetAttack()
        {
            if( m_LinkAttackData.AttackMutiType == E_AttackMultiType.Single)
            {
                m_TargetActor.SetDamage(m_AttackerActor, m_LinkAttackData.AddAttackVal);

            }
            else if(m_LinkAttackData.AttackMutiType == E_AttackMultiType.Multi)
            {
                //m_TargetActor.SetDamage(m_AttackerActor, m_LinkAttackData.AddAttackVal);

            }


            GameObject.Destroy(gameObject, 2f);
        }

        void Start()
		{
			
		}

		void Update()
		{
            if(!m_ISInit)
                return;

            float movespeed = m_MoveSpeed * Time.deltaTime;
            Vector3 direction = m_TargetActor.transform.position - this.transform.position;
            Vector3 direction2 = direction.normalized;

            if( direction.magnitude <= movespeed )
            {
                SetAttack();
            }
            else
            {
                this.transform.Translate(direction2 * movespeed);
            }
        }

	}

}