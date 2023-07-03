
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gconnect.Application.Common;
public static class ExpressionExtension
{
    ///// <summary>
    ///// Extension method to support dynamic sorting.
    ///// </summary>
    ///// <typeparam name="T">The entity type.</typeparam>
    ///// <param name="source">The entity list.</param>
    ///// <param name="statement">The order by statement.</param>
    ///// <returns></returns>
    //public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string statement)
    //{
    //    // NOTE: Currently only supports sorting of 1 column.
    //    string method = string.Empty;
    //    string[] parts = statement.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    //    // Determine sort order.
    //    method = (parts.Length > 1 && parts[1].ToUpper() == "DESC") ?
    //                "OrderByDescending" : "OrderBy";

    //    // Create dynamic expression.
    //    var type = typeof(T);
    //    var property = type.GetProperty(parts[0]);
    //    var parameter = Expression.Parameter(type, "param");
    //    var member = Expression.MakeMemberAccess(parameter, property);
    //    var lambda = Expression.Lambda(member, parameter);

    //    var finalExpression = Expression.Call(typeof(Queryable), method,
    //                            new Type[] { type, property.PropertyType },
    //                            source.Expression, Expression.Quote(lambda));

    //    return source.Provider.CreateQuery<T>(finalExpression);
    //}

    public static IQueryable<T> WhereMany<T>(this IQueryable<T> source, params Expression<Func<T, bool>>[] predicates)
    {
        if (predicates != null && predicates.Any())
        {
            foreach (var predicate in predicates)
            {
                source = source.Where(predicate);
            }
        }
        return source;
    }

    public static IQueryable<T> WhereMany<T>(this IQueryable<T> source, IEnumerable<Expression<Func<T, bool>>> predicates)
    {
        return source.WhereMany(predicates.ToArray());
    }

    public static IList<T> CastToList<T>(this IEnumerable source)
    {
        return new List<T>(source.Cast<T>());
    }

    public static Expression<Func<T1, T3>> CombineExpression<T1, T2, T3>(Expression<Func<T1, T2>> first, Expression<Func<T2, T3>> second)
    {
        var param = Expression.Parameter(typeof(T1), "param");

        var newFirst = new ReplaceVisitor(first.Parameters.First(), param)
            .Visit(first.Body);
        var newSecond = new ReplaceVisitor(second.Parameters.First(), newFirst)
            .Visit(second.Body);

        return Expression.Lambda<Func<T1, T3>>(newSecond, param);
    }

    public static Expression<Func<T1, T3>> Combine<T1, T2, T3>(this Expression<Func<T1, T2>> first, Expression<Func<T2, T3>> second)
    {
        return CombineExpression(first, second);
    }

    class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public ReplaceVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
}
