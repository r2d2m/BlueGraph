﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Graph2
{
    [CustomNodeView(typeof(MathNode))]
    class ExampleCustomNodeView : NodeView
    {
        public override void Initialize(AbstractNode node, EdgeConnectorListener connectorListener)
        {
            base.Initialize(node, connectorListener);

            Debug.Log("Initialize custom MathNode editor");
        }
    }
}