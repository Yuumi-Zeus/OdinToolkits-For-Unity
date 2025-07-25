using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Yuumix.OdinToolkits.Core;
using Yuumix.OdinToolkits.Shared;

namespace Yuumix.OdinToolkits.Editor
{
    /// <summary>
    /// 构造函数数据
    /// </summary>
    [Serializable]
    public class ConstructorData : MemberData
    {
        public bool isVirtual;
        public string parameters;

        public static ConstructorData FromConstructorInfo(ConstructorInfo constructorInfo, Type type)
        {
            var consData = new ConstructorData
            {
                belongToType = type.GetReadableTypeName(true),
                memberType = constructorInfo.MemberType,
                memberAccessModifierType = constructorInfo.GetMethodAccessModifierType(),
                isStatic = constructorInfo.IsStatic,
                isObsolete = constructorInfo.IsDefined(typeof(ObsoleteAttribute)),
                isVirtual = constructorInfo.IsVirtual,
                name = constructorInfo.DeclaringType?.Name,
                parameters = constructorInfo.GetParamsNames()
            };
            consData.accessModifier = consData.memberAccessModifierType.GetAccessModifierString();
            consData.fullSignature = consData.accessModifier + " " + constructorInfo.GetFullMethodName();
            IEnumerable<Attribute> attributes = constructorInfo.GetCustomAttributes();
            if (attributes
                    .FirstOrDefault(x => typeof(IMultiLanguageComment).IsAssignableFrom(x.GetType())) is not
                IMultiLanguageComment comment)
            {
                consData.chineseComment = "无";
                consData.englishComment = "No Comment";
                return consData;
            }

            consData.chineseComment = comment.GetChineseComment();
            consData.englishComment = comment.GetEnglishComment();
            return consData;
        }
    }
}
