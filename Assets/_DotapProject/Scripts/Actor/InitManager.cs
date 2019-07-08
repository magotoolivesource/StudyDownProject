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

        }


        public ActorTableData TempActorTableData = new ActorTableData();

        private void Awake()
        {
            TempActorTableData = ActorTableData.GetI;
            ActorTableData.GetI.Init();


        }

        void Start()
		{
			
		}

		void Update()
		{
			
		}
	}

}