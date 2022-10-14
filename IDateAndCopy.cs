using System;

namespace Person
{
    internal interface IDateAndCopy
    {
        object DeepCopy();
        DateTime date { get; set; }
    }
}
