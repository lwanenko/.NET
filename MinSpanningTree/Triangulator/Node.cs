using Duality;
using SnowyPeak.Duality.Plugin.Frozen.Procedural;
using System;
using System.Collections.Generic;
using System.Text;

namespace Triangulator
{
    public class Node : INode
    {
        public Vector2 Position { get; set; }

        public Node( Vector2 position)
        {
            Position = position;
        }

        public Node()
        {

        }

    }
}
