using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    public interface IObstacleMove
    {
        public void ObstacleMove();
    }
    public interface IMonsterAttackable
    {
        public void MonsterAttackable();
    }
}
