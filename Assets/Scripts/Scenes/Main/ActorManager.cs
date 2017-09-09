//担当：森田　勝
//概要：シーン内のActorを管理するクラス
//　　　各クラスでActor同士を参照するときにこのクラスを中継させたい
//参考：特になし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10.Main {
	public class ActorManager : MonoBehaviour {

		//プレイヤー
		public Player m_player { get; private set; }

		//TODO:EnemyManagerの作成

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			m_player = Instantiate(
				Resources.Load<GameObject>(Player.PREFAB_PASS) ,
				this.transform).GetComponent<Player>();
			m_player.Initialize();
		}

		/// <summary>
		/// 更新
		/// </summary>
		public void UpdateByFrame() {
			m_player.UpdateByFrame();
		}
	}
}