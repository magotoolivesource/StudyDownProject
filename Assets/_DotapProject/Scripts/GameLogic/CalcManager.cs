using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
	public class CalcManager
	{
        public static float Damageval( BaseActor p_actor, BaseActor p_targetactor )
        {
            float outdamageval = 1f;
            return outdamageval;
        }

        public static int GetActorCampTypeTOLayerMask(BaseActor p_actor)
        {
            if( p_actor.MyCamp == E_Camp.Max)
            {
                Debug.LogErrorFormat("캠프타입이 이상함 2 : {0}, {1}", p_actor.name, p_actor.MyCamp);
                return 0;
            }

            return LayerMask.GetMask(p_actor.MyCamp.ToString()); ;
        }

        public static int GetCampTypeTOLayerIndex( BaseActor p_actor )
        {
            switch (p_actor.MyCamp)
            {
                case E_Camp.MyCamp:
                    return LayerMask.NameToLayer(p_actor.MyCamp.ToString());
                    break;
                case E_Camp.EnemyCamp:
                    return LayerMask.NameToLayer(p_actor.MyCamp.ToString());
                    break;
                default:
                    Debug.LogErrorFormat("캠프타입이 이상함 : {0}, {1}", p_actor.name, p_actor.MyCamp);
                    break;
            }

            return 0;
        }

	}

}