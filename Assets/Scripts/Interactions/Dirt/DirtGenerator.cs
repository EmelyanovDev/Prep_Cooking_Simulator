using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Interactions.Dirt
{
    public class DirtGenerator : MonoBehaviour
    {
        [SerializeField] private Dirt dirtTemplate;
        [SerializeField] private float createDelay;
        
        private DirtPoint[] _createPoints;

        private void Awake() => _createPoints = GetComponentsInChildren<DirtPoint>();

        private void Start() => StartCoroutine(CreateDirt());

        private IEnumerator CreateDirt()
        {
            while (true)
            {
                yield return new WaitForSeconds(createDelay);

                var point = GetRandomPoint();

                if (point != null)
                {
                    var dirt = Instantiate(dirtTemplate, point.GetPosition(), Quaternion.identity);
                    dirt.Init(point);
                    point.SetBusy(true);
                }
            }
        }

        private DirtPoint GetRandomPoint()
        {
            List<DirtPoint> points = new List<DirtPoint>(_createPoints.Where(i => i.IsBusy == false));

            return points.Count == 0 ? null : points[Random.Range(0, points.Count)];
        }
    }
}
