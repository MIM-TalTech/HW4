using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Data.Common
{
    public abstract class NamedEntityData : UniqueEntityData
    {

        public string Name { get; set; }
        public string Code { get; set; }
    }
}
