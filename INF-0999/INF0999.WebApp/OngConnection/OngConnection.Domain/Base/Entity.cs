using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Base
{
    public abstract class Entity<T, TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TKey? Id { get; set; }

    }
}
