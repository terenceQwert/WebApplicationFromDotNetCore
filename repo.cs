using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace console
{
    [DataContract(Name ="repo")]    
    public class Repository
    {
        [DataMember(Name = "name")]
        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private string _name;
        [DataMember(Name ="description")]
        public string Description { get; set; }
        
        [DataMember(Name ="homepage")]
        public Uri HomePage { get; set; }
    }
}
