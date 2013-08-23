
﻿using System;
using AutoMapper;

namespace MetricsCorporation.BL.Mapping
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts);
        TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions> opts);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        object Map(object source, Type sourceType, Type destinationType);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination,
                                                Action<IMappingOperationOptions> opts);

        object Map(object source, object destination, Type sourceType, Type destinationType);
        object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts);

        object Map(object source, object destination, Type sourceType, Type destinationType,
                   Action<IMappingOperationOptions> opts);

        IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>();

        TypeMap[] GetAllTypeMaps();
    }

    public class MetricsMapper : IMapper
    {
        static MetricsMapper()
        {
            Mapper.AddProfile<GeneralProfile>();
            Mapper.AllowNullDestinationValues = false;
        }


        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
        {
            return Mapper.Map<TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions> opts)
        {
            return Mapper.Map<TSource, TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination,
                                                       Action<IMappingOperationOptions> opts)
        {
            return Mapper.Map<TSource, TDestination>(source, destination, opts);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, destination, sourceType, destinationType);
        }

        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return Mapper.Map(source, sourceType, destinationType, opts);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType,
                          Action<IMappingOperationOptions> opts)
        {
            return Mapper.Map(source, destination, sourceType, destinationType, opts);
        }

        public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
        {
            return Mapper.CreateMap<TSource, TDestination>();
        }

        public TypeMap[] GetAllTypeMaps()
        {
            return Mapper.GetAllTypeMaps();
        }
    }
}
﻿