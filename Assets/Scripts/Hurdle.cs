using System;
using UnityEngine;

public class Hurdle : MonoBehaviour
{
    private float _selfDestructIfOtherHurdleFoundRadius;
    private uint _selfDestructPriority;
    public static HurdleBuilder Builder => new HurdleBuilder();

    private Hurdle() { }

    private void OnEnable() => DestroySelfInCaseOfBadSpawn();


    private void DestroySelfInCaseOfBadSpawn( )
    {
        Hurdle maxPriorityHurdle = this;
        int otherHurdleCount = 0;

        foreach (Collider col in Physics.OverlapSphere(transform.position, _selfDestructIfOtherHurdleFoundRadius))
        {
            var hurdle = col.GetComponent<Hurdle>();
            if (hurdle != null && hurdle != this)
            {
                otherHurdleCount++;
                if(hurdle._selfDestructPriority > _selfDestructPriority)
                maxPriorityHurdle = hurdle;

            }
        }

        Destroy(maxPriorityHurdle);
        if (maxPriorityHurdle == this || otherHurdleCount==0) return;
        DestroySelfInCaseOfBadSpawn();

    }

    public class HurdleBuilder
    {
        internal HurdleBuilder() { }
        private Vector3 _worldPosition;
        private GameObject _prefab;
        private uint _selfDestructPriority;
        private float _selfDestructIfOtherHurdleFoundRadius;
        public HurdleBuilder SetWorldPosition(Vector3 worldPosition) { _worldPosition = worldPosition; return this; }
        public HurdleBuilder AttachToGameObject(GameObject prefab) {  _prefab = prefab; return this; }

        public HurdleBuilder SetSelfDestructPriority(uint priority) { _selfDestructPriority = priority; return this; }

        public Hurdle Build()
        {
             
            RaycastHit hitinfo = new();
            Physics.Raycast(new Ray(_worldPosition, Vector3.down), out hitinfo);
            Hurdle hurdle = 
                GameObject.Instantiate(_prefab, hitinfo.point,Quaternion.identity, null)
                .AddComponent<Hurdle>();
            hurdle._selfDestructPriority = _selfDestructPriority;
            hurdle._selfDestructIfOtherHurdleFoundRadius = _selfDestructIfOtherHurdleFoundRadius;
            return hurdle;
        }

    }
}
