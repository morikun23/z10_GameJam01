//担当：森田　勝
//概要：プレイヤーの動きを実装したクラス
//　　　状態別の処理はクラスを分けています。
//参考：特になし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Player : LadderUser{

		//プレハブファイルのパス
		public const string PREFAB_PASS = "Prefabs/Actor/Player";
		
		//梯子
		public LadderHolder m_ladderHolder { get; private set; }

		private PlayerViewer m_viewer { get; set; }

		//タスク
		public IActorCommand m_command { get; set; }
		
		/// <summary>
		/// 初期化
		/// </summary>
		public override void Initialize() {
			m_width = GetComponent<BoxCollider2D>().bounds.size.x;
			m_height = GetComponent<BoxCollider2D>().bounds.size.y;

			m_ladderHolder = new GameObject("Ladders").AddComponent<LadderHolder>();
			m_ladderHolder.Initialize();
			m_viewer = GetComponent<PlayerViewer>();
			m_viewer.Initialize(this);

			m_command = null;
		}

		/// <summary>
		/// 更新
		/// </summary>
		public override void UpdateByFrame() {

			m_currentFloor = Stage.GetCurrentFloor(transform.position.y);

			if (IsLadderUseFul()) {
				if (IsLadderUsing()) { m_currentLadderStatus = LadderStatus.USING; }
				else { m_currentLadderStatus = LadderStatus.USEFUL; }
			}
			else { m_currentLadderStatus = LadderStatus.FREE; }

			switch (m_currentLadderStatus) {
				case LadderStatus.USEFUL: OnLadderIsUseful(); break;
				case LadderStatus.USING: OnLadderisUsing(); break;
				case LadderStatus.FREE: OnLadderIsFree(); break;
			}

			//描画
			m_viewer.UpdateByFrame(this);

			//コマンドの実行
			if (m_command != null) {
				m_command.OnUpdate(this);
				m_command = null;
			}
		}

		/// <summary>
		/// 梯子が使用可能なときを処理する
		/// </summary>
		private void OnLadderIsUseful() {
			//右移動
			if (Input.GetKey(KeyCode.RightArrow)) {
				m_command = new RunRightCommand();
			}
			//左移動
			if (Input.GetKey(KeyCode.LeftArrow)) {
				m_command = new RunLeftCommand();
			}
			//上昇開始
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				m_command = new GoUpstairsCommand();
			}
			//下降開始
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				m_command = new GoDownstairsCommand();
			}
		

			//梯子を取り除く
			if (Input.GetKeyDown(KeyCode.Z)) {
				RemoveLadder(FindLadderFromUp());
			}
		}

		/// <summary>
		/// 梯子を使用中なときを処理する
		/// </summary>
		private void OnLadderisUsing() {
			if (Input.GetKey(KeyCode.UpArrow)) {
				if (IsCeiled()) {
					m_command = new ClimbCommand();
				}
				else {
					m_command = new UpstairsCommand();
				}
			}

			if (Input.GetKey(KeyCode.DownArrow)) {
				if (IsGrounded()) {
					m_command = new LandCommand();
				}
				else {
					m_command = new DownstairsCommand();
				}
			}
		}

		/// <summary>
		/// 梯子を使用していないとき
		/// </summary>
		private void OnLadderIsFree() {
			//右移動
			if (Input.GetKey(KeyCode.RightArrow)) {
				m_command = new RunRightCommand();
			}
			//左移動
			if (Input.GetKey(KeyCode.LeftArrow)) {
				m_command = new RunLeftCommand();
			}

			if (Input.GetKeyDown(KeyCode.Space)) {
				this.PutLadder();
			}
		}

		/// <summary>
		/// 梯子を置く
		/// </summary>
		private void PutLadder() {
			m_ladderHolder.PutLadder(m_currentFloor , transform.position.x);
		}

		private void RemoveLadder(Ladder arg_ladder) {
			if (arg_ladder == null) return;
			m_ladderHolder.RemoveLadder(arg_ladder);
		}
		
	}
}