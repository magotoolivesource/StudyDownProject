using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
	public class InitManager : MonoBehaviour
	{

        [ContextMenu("리소스파일 정보를 CSV로 저장")]
        void _Editor_SaveCSVFile()
        {

        }

        [ContextMenu("리소스파일 정보를 CSV로 로더")]
        void _Editor_LoadCSVFile()
        {
            TempActorTableData = ActorTableData.GetI;
            TempActorTableData.ActorTableAllDataList.Clear();
            ActorTableData.GetI.Init();


            TempAttackTableData = AttackTableData.GetI;
            TempAttackTableData.AttackAllTableDataList.Clear();
            AttackTableData.GetI.Init();
        }


        public ActorTableData TempActorTableData = new ActorTableData();
        public AttackTableData TempAttackTableData = new AttackTableData();
        private void Awake()
        {
            TempActorTableData = ActorTableData.GetI;
            ActorTableData.GetI.Init();


            TempAttackTableData = AttackTableData.GetI;
            AttackTableData.GetI.Init();



        }

        void Start()
		{
			
		}

		void Update()
		{
			
		}
	}

}