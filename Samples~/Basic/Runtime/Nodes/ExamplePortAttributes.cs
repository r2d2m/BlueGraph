﻿
using UnityEngine;
using BlueGraph;
using System.Collections.Generic;

namespace BlueGraphSamples
{
    /// <summary>
    /// Demo of different ways to configure ports
    /// </summary>
    [Node]
    public class ExamplePortAttributes : AbstractNode
    {
        // Public inputs are editable constants in the graph editor
        [Input] public float a = 1.0f;

        // Non-public inputs are not editable, and are expected to have connections.
        [Input] protected float b;

        // You can specify a custom name to override the default
        [Input("C In")] protected float c;
    
        // Port that can accept multiple output edges into itself. 
        [Input(name = "More Floats", multiple = true)] protected float d;
    
        // Outputs still need to be assigned to a field, even if we don't use that field. 
        // In more advanced use cases, you can potentially use the field for memoization.
        [Output("Sum")] protected float m_Sum;
        [Output("Multiply")] protected float m_Multiply;
        
        public override object OnRequestValue(Port port)
        {
            // Get connection value from connection a. 
            // If a isn't connected, this defaults to the 
            // value stored in this node instance.
            float fa = GetInputValue("a", a);
            float fb = GetInputValue("b", b);
            float fc = GetInputValue("C In", c); 
        
            // If a port supports multiple connections,
            // you can retrieve each value as an enumerable.
            IEnumerable<float> fd = GetInputValues<float>("More Floats");

            // Send to outputs
            if (port.name == "Sum")
            {
                float sum = fa + fb + fc;
                foreach (float f in fd)
                {
                    sum += f;
                }

                return sum;
            }

            // "Multiply" port
            return fa - fb - fc;
        }
    }
}
