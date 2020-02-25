using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Quickly create a pool of different object that is acessed with a random approach. This pool can't be reduced in size.
    /// </summary>
    public class ObjectRandomAccessPool
    {
        private GameObject[] templateArray;
        private List<GameObject> objectsList;

        /// <summary>
        /// Total number of objects at the pool.
        /// </summary>
        public int Count { get => objectsList.Count; }
        /// <summary>
        /// Total number of distinct template objects in the pool.
        /// </summary>
        public int TemplateObjectCount { get => templateArray.Length; }

        /// <summary>
        /// Instantiates each object in the array X times.
        /// </summary>
        /// <param name="templateCount">Number of times to instantiate each object.</param>
        /// <param name="templateArray">Array of objects that will be instantiated.</param>
        public ObjectRandomAccessPool(int templateCount, params GameObject[] templateArray)
        {
            this.templateArray = templateArray;
            objectsList = new List<GameObject>();

            foreach (GameObject obj in templateArray)
            {
                for (int i = 0; i < templateCount; i++)
                {
                    GameObject currentObj = Object.Instantiate(obj);
                    currentObj.SetActive(false);
                    objectsList.Add(currentObj);
                }
            }
        }

        /// <summary>
        /// Gets an object from the pool, sets it to a position, and makes it active. If there is no objects in the pool, instantiates a new one.
        /// </summary>
        /// <param name="position">Position for this object to start.</param>
        public GameObject GetRandomObject(Vector3 position)
        {
            GameObject obj;
            if (objectsList.Count > 0)
            {
                int randomIndex = Random.Range(0, objectsList.Count);
                obj = objectsList[randomIndex];
                objectsList.Remove(obj);
            }
            else
            {
                obj = Object.Instantiate(templateArray[Random.Range(0, templateArray.Length)]);
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
            objectsList.Add(obj);
            obj.SetActive(false);
        }
    }
}

