﻿using AutoMapper;

namespace CleanArchitecture.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
