using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Du3Project
{
	public class UIInGameActorButton : MonoBehaviour
	{
        public int ActorIndex = -1;

        [Header("[버턴 참고용 이미지]")]
        public Image ChildButtonImage = null;
        

        public void _OnButtonClick()
        {
            InGameBattleManager.GetI.AddPlayerActor(ActorIndex);
        }


        private void Awake()
        {
            ActorData data = ActorTableData.GetI.GetActorTableData(ActorIndex);
            ChildButtonImage.sprite = data.ActorSpriteImage;

        }



        void Start()
		{
			
		}   

		void Update()
		{
			
		}
	}

}