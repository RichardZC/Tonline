//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BE
{
    using System;
    using System.Collections.Generic;
    
    public partial class serie
    {
        public int SerieId { get; set; }
        public string Codigo { get; set; }
        public Nullable<int> ArticuloId { get; set; }
        public Nullable<int> MovimientoDetEntId { get; set; }
        public Nullable<int> MovimientoDetSalId { get; set; }
    
        public virtual articulo articulo { get; set; }
        public virtual movimientodet movimientodet { get; set; }
        public virtual movimientodet movimientodet1 { get; set; }
    }
}
