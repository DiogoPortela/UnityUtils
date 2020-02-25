using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.AI
{
    public class DTMultipleDecision : IDTNode
    {
        IDTNode[] nodes;
        Func<int> condition;

        public DTMultipleDecision(Func<int> condition, params IDTNode[] nodes)
        {
            this.nodes = nodes;
            this.condition = condition;
        }

        public void Run()
        {
            int result = condition();
            if (result > 0 && result < nodes.Length - 1)
                nodes[result].Run();
            else
                Debug.Log($"Condition has returned a result that excedes the number of nodes. Max : {nodes.Length} . Result : {result}");
        }
    }
}

