using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
    public class EnemyDeadState : IEnemyState
    {

        float m_xspeed = 0.1f;
        float m_yspeed = 0.7f;
        float m_decreaseY = 0.05f;

        SpriteRenderer m_visible;

        //この秒数経過したら終了
        float m_endTime = 1;
        float m_elapsedTime = 0;

        public void OnEnter(ActorEnemy arg_enemy)
        {
            m_visible = arg_enemy.GetComponent<SpriteRenderer>();
            //当たり判定を消す
            arg_enemy.GetComponent<BoxCollider2D>().enabled = false;
        }

        public void OnUpdate(ActorEnemy arg_enemy)
        {
            //点滅
            m_visible.enabled = !m_visible.enabled;

            m_yspeed -= m_decreaseY;

            //Directionで吹き飛ぶｘ軸と回転の仕方を制御
            if (arg_enemy.m_direction == ActorBase.Direction.LEFT)
            {
                arg_enemy.transform.RotateAround(arg_enemy.transform.position,Vector3.forward,30);
                arg_enemy.transform.position += new Vector3(-m_xspeed, m_yspeed);
            }
            else if (arg_enemy.m_direction == ActorBase.Direction.RIGHT) {

                arg_enemy.transform.RotateAround(arg_enemy.transform.position, Vector3.forward, -30);
                arg_enemy.transform.position += new Vector3(m_xspeed, m_yspeed);
            }


            //一定時間経過したら
            m_elapsedTime += Time.deltaTime;

            if (m_elapsedTime > m_endTime) {
                //ステート遷移？？
                //消滅？？
                //リストから消す？？
            }
        }

        public void OnExit(ActorEnemy arg_enemy)
        {

        }

    }
}