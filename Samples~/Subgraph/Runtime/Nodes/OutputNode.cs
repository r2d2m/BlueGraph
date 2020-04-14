
using System;
using UnityEngine;
using BlueGraph;

namespace BlueGraphSamples
{
    [Node("Output", module = "Subgraph/IO")]
    public class OutputNode : AbstractNode
    {
        // Input port is dynamically generated by the editor.

        /// <summary>
        /// Not directly called for this node type
        /// </summary>
        public override object OnRequestValue(Port port) => null;
        
        public OutputNode()
        {
            AddPort(new Port
            {
                isInput = true,
                acceptsMultipleConnections = false,
                Type = typeof(float)
            });
        }
    }
}