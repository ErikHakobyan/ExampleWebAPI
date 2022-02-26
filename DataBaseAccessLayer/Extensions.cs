using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessLayer;

internal static class Extensions
{
    public static IEnumerable<T> OrderDynamic<T>(this IEnumerable<T> Data, string propToOrder)
    {
        if (typeof(T).GetProperty(propToOrder) == null)
            throw new SortException(propToOrder, typeof(T));
        var param = Expression.Parameter(typeof(T));
        var memberAccess = Expression.Property(param, propToOrder);
        var convertedMemberAccess = Expression.Convert(memberAccess, typeof(object));
        var orderPredicate = Expression.Lambda<Func<T, object>>(convertedMemberAccess, param);

        return Data.AsQueryable().OrderBy(orderPredicate).ToArray();
    }
}

