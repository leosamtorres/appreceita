//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppControleReceita.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class fin_credito_debito
    {
        [Key]
        [Column(Order = 1)]
        public int FCD_CODIGO { get; set; }
        public decimal FCD_VALOR { get; set; }
        public int CAT_CODIGO { get; set; }
        public DateTime FCD_DATA_CADASTRO { get; set; }


        [NotMapped]
        public string FCD_TIPO { get; set; }
        [NotMapped]
        public string MesAnoPesquisa { get; set; }
        [NotMapped]
        public string CAT_TIPO { get; set; }

        [NotMapped]
        public string FCD_VALORS { get; set; }

    }
}
