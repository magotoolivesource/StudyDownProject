﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Du3Project
{
    [System.Serializable]
    public class AttackTableData : SingletonTample<AttackTableData>
    {
        public List<AttackData> AttackAllTableDataList = new List<AttackData>();
        protected Dictionary<int, AttackData> m_AttackAllTableDataDic = new Dictionary<int, AttackData>();

        public AttackData GetAttackDataID(int p_id)
        {
            if (m_AttackAllTableDataDic.ContainsKey(p_id))
            {
                return m_AttackAllTableDataDic[p_id];
            }

            return null;
        }


        public void Init()
        {
            AttackAllTableDataList.Clear();
            m_AttackAllTableDataDic.Clear();


            AttackData tempattackdata = null;
            string FolderName = Application.dataPath + "/Resources";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderName);
            string tempstr = "";
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".asset") == 0)
                {
                    tempstr = Path.GetFileNameWithoutExtension(File.Name);

                    tempattackdata = Resources.Load<AttackData>(tempstr);

                    if(tempattackdata)
                    {
                        AttackAllTableDataList.Add(tempattackdata);


                        if (!m_AttackAllTableDataDic.ContainsKey(tempattackdata.AttackID))
                        {
                            m_AttackAllTableDataDic.Add(tempattackdata.AttackID, tempattackdata);
                        }
                        else
                        {
                            Debug.LogErrorFormat(" 공격 데이터 중복되는 인덱스가 있음 : {0}, {1}", File.FullName, tempattackdata.AttackID);
                        }

                    }
                }
            }

        }


    }




    [System.Serializable]
	public class ActorTableData : SingletonTample<ActorTableData>
	{
        public List<ActorData> ActorTableAllDataList = new List<ActorData>();

        protected Dictionary<int, ActorData> m_ActorTableAllDataMap = new Dictionary<int, ActorData>();
        public System.Collections.Generic.Dictionary<int, Du3Project.ActorData> ActorTableAllDataMap
        {
            get { return m_ActorTableAllDataMap; }
            protected set { m_ActorTableAllDataMap = value; }
        }

        protected Dictionary<string, ActorData> m_ActorTableAllDataNameMap = new Dictionary<string, ActorData>();
        public System.Collections.Generic.Dictionary<string, Du3Project.ActorData> ActorTableAllDataNameMap
        {
            get { return m_ActorTableAllDataNameMap; }
            protected set { m_ActorTableAllDataNameMap = value; }
        }

        public ActorData GetActorTableData(string p_name)
        {
            if (!m_ActorTableAllDataNameMap.ContainsKey(p_name))
            {
                return null;
            }

            ActorData outdata = new ActorData(  m_ActorTableAllDataNameMap[p_name] );
            return outdata;
        }

        public bool ISGetActortableData(int p_idindex)
        {
            if (m_ActorTableAllDataMap.ContainsKey(p_idindex))
                return true;

            return false;
        }

        public ActorData GetActorTableData(int p_idindex)
        {
            if( !m_ActorTableAllDataMap.ContainsKey(p_idindex))
            {
                return null;
            }

            ActorData outdata = new ActorData(m_ActorTableAllDataMap[p_idindex]);
            return outdata;
        }

        //public ActorData GetActorTableData( int p_idindex)
        //{
        //    return ActorTableAllDataList.Find( (data) => data.ID == p_idindex );
        //}


       


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
            m_ActorTableAllDataMap.Clear();
            m_ActorTableAllDataNameMap.Clear();


            ActorData tempactordata = null;
            string FolderName = Application.dataPath + "/Resources";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderName);
            string tempstr = "";
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".asset") == 0)
                {
                    tempstr = Path.GetFileNameWithoutExtension(File.Name);
                    //Debug.LogFormat("Load Asset File : {0}\n {1}", File.Name
                    //    , File.FullName
                    //    , tempstr
                    //    );

                    tempactordata = Resources.Load<ActorData>(tempstr);

                    if(tempactordata)
                    {
                        ActorTableAllDataList.Add(tempactordata);


                        if (!m_ActorTableAllDataMap.ContainsKey(tempactordata.ID))
                        {
                            m_ActorTableAllDataMap.Add(tempactordata.ID, tempactordata);
                        }
                        else
                        {
                            Debug.LogErrorFormat("중복되는 인덱스가 있음 : {0}, {1}", File.FullName, tempactordata.ID);
                        }

                        if (!m_ActorTableAllDataNameMap.ContainsKey(tempactordata.Name))
                        {
                            m_ActorTableAllDataNameMap.Add(tempactordata.Name, tempactordata);
                        }
                        else
                        {
                            Debug.LogErrorFormat("중복되는 이름이 있음 : {0}, {1}", File.FullName, tempactordata.ID);
                        }
                    }

                }
            }



            //tempactordata =  Resources.Load<ActorData>("ActorData01");
            //ActorTableAllDataList.Add(tempactordata);

            // 2번째 로드
            




        }




		
	}

}