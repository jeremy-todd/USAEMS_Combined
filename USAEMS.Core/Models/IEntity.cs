using System;
using System.Collections.Generic;
using System.Text;

namespace USAEMS.Core.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}