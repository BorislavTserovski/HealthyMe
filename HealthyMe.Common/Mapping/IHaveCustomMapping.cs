using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Common.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
