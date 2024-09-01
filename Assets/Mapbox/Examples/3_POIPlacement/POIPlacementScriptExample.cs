namespace Mapbox.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Mapbox.Unity.Map;
    using Mapbox.Utils;

    public class POIPlacementScriptExample : MonoBehaviour
    {
        public AbstractMap map;

        //prefab to spawn
        public GameObject prefab;
        //cache of spawned gameobjects
        private List<GameObject> _prefabInstances;

        // Use this for initialization
        void Start()
        {
            // Van Yüzüncü Yıl Üniversitesi'nin koordinatlarını kullanarak haritayı başlat
            map.Initialize(new Vector2d(38.501026, 43.399671), 15);

            // Haritaya bir işaretçi eklemek için prefab kullanımı
            SpawnMarkerAtLocation(new Vector2d(38.501026, 43.399671));
        }

        // Belirli bir konuma işaretçi ekleme
        void SpawnMarkerAtLocation(Vector2d coordinates)
        {
            // Prefab'ı istenen konuma spawn et
            var instance = Instantiate(prefab);
            instance.transform.position = map.GeoToWorldPosition(coordinates, true);
            _prefabInstances.Add(instance);
        }

        //handle callbacks
        void HandlePrefabSpawned(List<GameObject> instances)
        {
            if (instances.Count > 0)
            {
                Debug.Log(instances[0].name);
            }
        }
    }
}
