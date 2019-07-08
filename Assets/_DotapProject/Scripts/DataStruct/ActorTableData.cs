using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Du3Project
{
    [System.Serializable]
	public class ActorTableData : SingletonTample<ActorTableData>
	{
        public List<ActorData> ActorTableAllDataList = new List<ActorData>();

        public ActorData GetActorTableData( int p_idindex)
        {
            return ActorTableAllDataList.Find( (data) => data.ID == p_idindex );
        }


       


        public void Init()
        {
            // 
            //ActorData tempactordata = new ActorData();
            //tempactordata.ID = 0;
            //tempactordata.Name = "나주인공";
            //tempactordata.Descript = "킹왕짱 주인공";
            //ActorTableAllDataList.Add(tempactordata);


            //tempactordata = new ActorData();
            //tempactordata.ID = 1;
            //tempactordata.Name = "비련의 주인공";
            //tempactordata.Descript = "1인자만 기억되는 비열한 세상을 비관한 등등";
            //ActorTableAllDataList.Add(tempactordata);


            ActorTableAllDataList.Clear();


            ActorData tempactordata = null;
            string FolderName = Application.dataPath + "/Resources";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderName);
            string tempstr = "";
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".asset") == 0)
                {
                    tempstr = Path.GetFileNameWithoutExtension(File.Name);
                    Debug.LogFormat("Load Asset File : {0}\n {1}", File.Name
                        , File.FullName
                        , tempstr
                        );

                    tempactordata = Resources.Load<ActorData>(tempstr);
                    ActorTableAllDataList.Add(tempactordata);
                }
            }



            //tempactordata =  Resources.Load<ActorData>("ActorData01");
            //ActorTableAllDataList.Add(tempactordata);

            // 2번째 로드
            




        }




		
	}

}