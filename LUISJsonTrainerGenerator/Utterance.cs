using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUISJsonTrainerGenerator
{
    class Utterance
    {
        public string text { get; set; }
        public string intent { get; set; }
        public List<EntityInfo> entities { get; set; }
        public Utterance(string text, string intent, List<EntityInfo> entities) {
            this.text = text;
            this.intent = intent;
            this.entities = entities;
        }
    }
}
