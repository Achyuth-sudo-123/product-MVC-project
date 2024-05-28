namespace productMVCproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productTable")]
    public partial class productTable
    {
        public int id { get; set; }

        public int? brand_id { get; set; }

        public int? categori_id { get; set; }

        public int? quentity { get; set; }

        public decimal? price { get; set; }

        public virtual BrandTable BrandTable { get; set; }

        public virtual CategoriTable CategoriTable { get; set; }
    }
}
