using System;
using Yuumix.OdinToolkits.Shared;

namespace Yuumix.OdinToolkits.Core
{
    [Serializable]
    public readonly struct MultiLanguageData : IEquatable<MultiLanguageData>
    {
        public static readonly MultiLanguageData Default = new MultiLanguageData("Null");
        public static MultiLanguageData[] EmptyArray = Array.Empty<MultiLanguageData>();
        readonly string _chinese;
        readonly string _english;

        public MultiLanguageData(string chinese, string english = null)
        {
            _chinese = chinese;
            _english = english ?? string.Empty;
        }

        public string GetCurrentOrFallback()
        {
            if (InspectorMultiLanguageSetting.IsChinese)
            {
                return _chinese;
            }

            if (InspectorMultiLanguageSetting.IsEnglish && !_english.IsNullOrWhiteSpace())
            {
                return _english;
            }

            return _chinese;
        }

        public string GetChinese() => _chinese;
        public string GetEnglish() => _english;
        public override string ToString() => GetCurrentOrFallback();
        public bool Equals(MultiLanguageData other) => _chinese == other._chinese && _english == other._english;
        public override bool Equals(object obj) => obj is MultiLanguageData other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(_chinese, _english);

        /// <summary>
        /// 隐式类型转换，MultiLanguageData -> String
        /// </summary>
        public static implicit operator string(MultiLanguageData data) => data.GetCurrentOrFallback();
    }
}
