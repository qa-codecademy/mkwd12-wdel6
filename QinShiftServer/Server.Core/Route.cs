using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Core
{
    internal class Route (string name)
    {
        public string Name { get; } = name;

        public bool Matches(string path)
        {
            return path.StartsWith($"/{Name}", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
