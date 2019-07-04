using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
	public class CollisionDetaing : MonoBehaviour
	{
        [SerializeField, ShowOnly]
        BaseActor m_LinkActor = null;
        [SerializeField, ShowOnly]
        Action<BaseActor> m_CallFN = null;

        public void InitCollisionDetating( BaseActor  p_linkactor,  Action<BaseActor> p_callfn )
        {
            m_LinkActor = p_linkactor;
            m_CallFN = p_callfn;
        }

        private void OnTriggerEnter(Collider p_other)
        {
            BaseActor otheractor = p_other.GetComponent<BaseActor>();
            if( otheractor
                && otheractor.MyCamp != m_LinkActor.MyCamp)
            {
                m_CallFN(otheractor);

            }
            
        }



        void Start()
		{
			
		}

		void Update()
		{
			
		}
	}

}