using System;

namespace Wathet.Common.Attributes
{
    public class StringLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; } = 0;
    }
}