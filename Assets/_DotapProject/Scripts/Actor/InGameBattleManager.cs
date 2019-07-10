using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
	public class InGameBattleManager : Singleton_Mono<InGameBattleManager>
	{
        public Transform PlayerActorSpawn = null;
        public Transform EnemyActorSpawn = null;

        // 프리팹에서 가지고 오기
        public BaseActor CloneActorData = null;

        public RangeAttackObject CloneAttackObject = null;

        public RangeAttackObject AddRangeAttackObject( BaseActor p_target, BaseActor p_attacker, AttackData p_attackdata )
        {
            RangeAttackObject attackobj = GameObject.Instantiate<RangeAttackObject>(CloneAttackObject);
            attackobj.Initlize(p_target, p_attacker, p_attackdata);

            return attackobj;
        }



        public BaseActor AddPlayerActor( int p_index, E_Camp p_camp = E_Camp.MyCamp )
        {

            if( !ActorTableData.GetI.ISGetActortableData(p_index) )
            {
                Debug.LogErrorFormat("생성 할수 없음  : {0}", p_index);
                return null;
            }


            BaseActor cloneactor = GameObject.Instantiate<BaseActor>( CloneActorData );
            cloneactor.ActorTableID = p_index;
            cloneactor.InitSettingData(p_index, p_camp);

            cloneactor.gameObject.SetActive(true);

            if(p_camp == E_Camp.MyCamp)
            {
                cloneactor.transform.SetParent(PlayerActorSpawn);
            }
            else if(p_camp == E_Camp.EnemyCamp)
            {
                cloneactor.transform.SetParent(EnemyActorSpawn);
            }
            else
            {
                Debug.LogErrorFormat(" 진영이 없습니다. ");
            }

            cloneactor.transform.localPosition = new Vector3(0f, 0f, 0f);

            return cloneactor;
        }


        IEnumerator Test_EnemyDatas()
        {
            for (int i = 0; i < 4; i++)
            {
                AddPlayerActor(i, E_Camp.EnemyCamp);

                yield return new WaitForSeconds(2);
            }

        }


		void Start()
		{
            StartCoroutine( Test_EnemyDatas() );
		}

		void Update()
		{
			
		}
	}

}