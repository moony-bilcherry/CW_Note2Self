using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self
{
    /// <summary>
    /// Класс в помощь выражениям
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Компилирует выражение и получает возвращаемое функцией значение
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="lamba">Выражение для компиляции</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba)
        {
            return lamba.Compile().Invoke();
        }

        /// <summary>
        /// Устанавливает значение в указанное свойство
        /// </summary>
        /// <typeparam name="T">Тип устанавливаемого значения</typeparam>
        /// <param name="lamba">Выражение</param>
        /// <param name="value">Значение</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamba, T value)
        {
            // Конвертирует lamba () => some.Property в some.Property
            var expression = (lamba as LambdaExpression).Body as MemberExpression;

            // Получает информацию о свойстве
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // Устанавливает значение в свойство
            propertyInfo.SetValue(target, value);

        }
    }
}