﻿using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Infra.Quantity
{
    public class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {
        public UnitsRepository(QuantityDbContext c) : base(c, c.Units)
        {

        }
     
        protected internal override Unit toDomainObject(UnitData d)
        {
            return new Unit(d);
        }
    }
}