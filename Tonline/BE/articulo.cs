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
    
    public partial class articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public articulo()
        {
            this.caracteristica = new HashSet<caracteristica>();
            this.articulodet = new HashSet<articulodet>();
            this.serie = new HashSet<serie>();
            this.inventario = new HashSet<inventario>();
            this.movimientodet = new HashSet<movimientodet>();
        }
    
        public int ArticuloId { get; set; }
        public int MarcaId { get; set; }
        public int CategoriaId { get; set; }
        public string Codigo { get; set; }
        public string Denominacion { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
        public string Detalle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<caracteristica> caracteristica { get; set; }
        public virtual categoria categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<articulodet> articulodet { get; set; }
        public virtual marca marca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<serie> serie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inventario> inventario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimientodet> movimientodet { get; set; }
    }
}
