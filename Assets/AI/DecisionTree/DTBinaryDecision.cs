using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.AI
{
    public class DTBinaryDecision : IDTNode
    {
        Func<bool> condition;
        IDTNode trueNode;
        IDTNode falseNode;

        public DTBinaryDecision(Func<bool> condition, IDTNode trueNode, IDTNode falseNode)
        {
            this.condition = condition;
            this.falseNode = falseNode;
            this.trueNode = trueNode;
        }

        public void Run()
        {
            if (condition())
            {
                trueNode.Run();
            }
            falseNode.Run();
        }
    }
}

