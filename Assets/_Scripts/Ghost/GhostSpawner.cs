using UnityEngine;

namespace _Scripts.Ghost
{
    public class GhostSpawner
    {
        private readonly Transform _ghostVector1;
        private readonly Transform _ghostVector2;
        private readonly GhostFactory _ghostFactory;
        
        public GhostSpawner(Transform ghostVector1, Transform ghostVector2, GhostFactory ghostFactory)
        {
            _ghostVector1 = ghostVector1;
            _ghostVector2 = ghostVector2;
            _ghostFactory = ghostFactory;
        }

        public void Spawn(GhostData data,Transform parent)
        {
            float posEnemyX = Random.Range(
                Mathf.Max(_ghostVector1.position.x, _ghostVector2.position.x),
                Mathf.Min(_ghostVector1.position.x, _ghostVector2.position.x)
                );
            float posEnemyZ = Random.Range(
                Mathf.Max(_ghostVector1.position.z, _ghostVector2.position.z),
                Mathf.Min(_ghostVector1.position.z, _ghostVector2.position.z)
                );
            Ghost enemy = _ghostFactory.Create(data);
            enemy.transform.position = new Vector3(posEnemyX, 1f, posEnemyZ);
            enemy.transform.SetParent(parent);
            
        }
    }
}