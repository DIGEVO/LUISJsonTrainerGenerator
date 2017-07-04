using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUISJsonTrainerGenerator
{
    class EntityInfo
    {
        public string entity { get; set; }
        public int startPos { get; set; }
        public int endPos { get; set; }
        public EntityInfo(string entity, int startPos, int endPos)
        {
            this.entity = entity;
            this.startPos = startPos;
            this.endPos = endPos;
        }
    }
}
