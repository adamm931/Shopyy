using AutoMapper;
using Shoppy.Application.Exceptions;
using Shopyy.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shoppy.Application.Mapping.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSrc, TDst> For<TSrc, TDst, TSrcProp, TDstProp>(
            this IMappingExpression<TSrc, TDst> mapping,
            Expression<Func<TSrc, TSrcProp>> source,
            Expression<Func<TDst, TDstProp>> destination)
        {
            return mapping.ForMember(destination, opts => opts.MapFrom(source));
        }

        public static IMappingExpression<TSrc, TDst> Path<TSrc, TDst, TSrcProp, TDstProp>(
            this IMappingExpression<TSrc, TDst> mapping,
            Expression<Func<TSrc, TSrcProp>> source,
            Expression<Func<TDst, TDstProp>> destination)
        {
            return mapping.ForPath(destination, opts => opts.MapFrom(source));
        }

        public static IMappingExpression<TSrc, TDst> For<TSrc, TDst, TSrcProp, TDstProp>(
           this IMappingExpression<TSrc, TDst> mapping,
           Func<TSrc, TDst, TDstProp, ResolutionContext> source,
           Expression<Func<TDst, TDstProp>> destination)
        {
            /*(src, dest, destMember, context) => context.Items["Foo"])*/

            return mapping.ForMember(destination, opt => opt.MapFrom(source));
        }

        public static IMappingExpression<TSrc, TDst> Ignore<TSrc, TDst, TDstProp>(
           this IMappingExpression<TSrc, TDst> mapping,
           Expression<Func<TDst, TDstProp>> destination)
        {
            return mapping.ForMember(destination, opt => opt.Ignore());
        }

        public static TItem GetItem<TItem>(this ResolutionContext context, string name)
            where TItem : class
        {
            return context.Items.TryGetValue(name, out var value)
                ? (TItem)value
                : throw new ResolutionContextItemNotFoundException(name);

        }

        public static TDst Map<TDst>(this IMapper mapper, object source, IDictionary<string, object> paramters)
        {
            return mapper.Map<TDst>(source, opts =>
            {
                opts.Items.AddFrom(paramters);
            });
        }
    }
}
