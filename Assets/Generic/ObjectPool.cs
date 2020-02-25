using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Quickly create a pool of the same object that is acessed in a FIFO approach.
    /// </summary>
    public class ObjectPool
    {
        private GameObject template;
        private Queue<GameObject> objectsQueue;

        /// <summary>
        /// Number of objects at the pool.
        /// </summary>
        public int Count { get => objectsQueue.Count; }

        /// <summary>
        /// Instantiates the template object X times, and adds them to the pool.
        /// </summary>
        /// <param name="poolCount">Number of times to spawn the template object.</param>
        /// <param name="template">Template object to spawn.</param>
        public ObjectPool(int poolCount, GameObject template)
        {
            this.template = template;
            objectsQueue = new Queue<GameObject>();
            for (int i = 0; i < poolCount; i++)
            {
                GameObject obj = Object.Instantiate(template);
                obj.SetActive(false);
                objectsQueue.Enqueue(obj);
            }
        }

        /// <summary>
        /// Forces the pool to have X objects in the pool.
        /// </summary>
        /// <param name="poolCount">Number of objects to have in the pool.</param>
        public void SetPoolCount(int poolCount)
        {
            int result = 0;
            while (objectsQueue.Count > poolCount)
            {
                Object.Destroy(objectsQueue.Dequeue());
                result--;
            }
            while (objectsQueue.Count < poolCount)
            {
                objectsQueue.Enqueue(Object.Instantiate(template));
                result++;
            }

            if (result > 0)
                Debug.Log($"Pool of {template.name} has increased by {result}.");
            else if (result < 0)
                Debug.Log($"Pool of {template.name} has decreased by {-result}.");
            else
                Debug.Log($"Pool of {template.name} did not change.");
        }

        /// <summary>
        /// Gets an object from the pool, sets it to a position, and makes it active. If there is no objects in the pool, instantiates a new one.
        /// </summary>
        /// <param name="position">Position for this object to start.</param>
        public GameObject GetObject(Vector3 position)
        {
            GameObject obj;
            if (objectsQueue.Count > 0)
                obj = objectsQueue.Dequeue();
            else
            {
                obj = Object.Instantiate(template);
                Debug.Log($"{obj.name} has been spawn outside the inital spawn time. Please increase the number of spawns available at initialization.");
            }

            obj.transform.position = position;
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Adds an object to the pool and deactivates it.
        /// </summary>
        /// <param name="obj"></param>
        public void GiveObject(GameObject obj)
        {
            objectsQueue.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}

