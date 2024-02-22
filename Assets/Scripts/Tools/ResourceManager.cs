using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class ResourceManager<T> : Singleton<ResourceManager<T>> where T : Component
    {
        [Serializable]
        public class ObjectPool
        {
            [Tooltip("Pool's name"), SerializeField]
            private string name;
            public string Name { get => name; }

            [Tooltip("The object to instantiate"), SerializeField]
            internal GameObject prefab;
            [Tooltip("The pool of instantated objects"), SerializeField]
            private readonly List<T> pool = new List<T>();
            public List<T> Pool { get => pool; }
            private Transform objectsParent;

            internal ObjectPool(string name = "", GameObject prefab = null, Transform parent = null)
            {
                this.name = name;
                this.prefab = prefab;
                objectsParent = new GameObject(name: Name).transform;
                objectsParent.SetParent(parent);
            }

            /// <summary>
            /// Pop the first object from the pool and put it to the back of the queue/pool then returns it. Instantiate a new one if none is available
            /// </summary>
            /// <param name="position">Position of the object</param>
            /// <param name="rotation">Rotation of the object</param>
            public T Get(Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
            {
                if (!pool[0].gameObject.activeSelf)
                {
                    var obj = pool[0];
                    pool.Remove(pool[0]);
                    pool.Add(obj);
                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    pool.Add(Instantiate(prefab, position, rotation, parent: objectsParent).GetComponent<T>());
                    return pool[pool.Count - 1];
                }
            }

            /// <summary>
            /// Destroyes currently disabled objects
            /// </summary>
            public void DestroyUnused()
            {
                for (int i = 0; i < pool.Count; i++)
                {
                    if (!pool[i].gameObject.activeInHierarchy)
                    {
                        Destroy(pool[i]);
                        pool.Remove(pool[i]);
                    }
                }
            }

            /// <summary>
            /// Destroyes all objects
            /// </summary>
            public void DestroyAll()
            {
                for (int i = 0; i < pool.Count; i++)
                    Destroy(pool[i]);

                pool.Clear();
            }

            /// <summary>
            /// Instantiates new objects to the pool
            /// </summary>
            /// <param name="count">Number of objects to prepare</param>
            public void Prepare(int count = 0)
            {
                for (int i = 0; i < count; i++)
                {
                    pool.Add(Instantiate(prefab,parent: objectsParent).GetComponent<T>());
                    pool[pool.Count - 1].gameObject.SetActive(false);
                }
            }
        }

        //A transform to store inactive objects
        private static Transform inactiveObjects;
        private static Transform InactiveObjects
        {
            get
            {
                if (!inactiveObjects)
                    inactiveObjects = new GameObject("Pool").transform;

                return inactiveObjects;
            }
        }

        public List<ObjectPool> pools = new List<ObjectPool>();


        /// <summary>
        /// Get a pool by its name
        /// </summary>
        /// <param name="name"></param>
        public ObjectPool GetPool(string name)
        {
            foreach(ObjectPool pool in pools)
            {
                if(pool.Name == name)
                {
                    return pool;
                }
            }
            return null;
        }

        /// <summary>
        /// Create a pool by name and prefab
        /// </summary>
        /// <param name="name"></param>
        public ObjectPool CreatePool(string name, GameObject prefab)
        {
            ObjectPool newPool = new ObjectPool(name, prefab);
            pools.Add(newPool);
            return newPool;
        }


        /// <summary>
        /// Disables the object and moves it under the Pool object
        /// </summary>
        /// <param name="obj">Object to disable</param>
        public static void Remove(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(InactiveObjects);
        }
    }
}