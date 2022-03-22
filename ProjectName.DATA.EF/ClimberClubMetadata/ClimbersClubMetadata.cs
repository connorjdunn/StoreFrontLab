using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Added for metadata and validation

namespace ProjectName.DATA.EF.ClimberClub//Metadata
{
    #region CategoryMetadata

    class CategoryMetadata
    {
        [Required]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }

    }

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category { }

    #endregion

    #region Department Metadata

    class DepartmentMetadata
    {
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(20)]
        public string Description { get; set; }

    }

    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department { }

    #endregion

    #region Employee Metadata

    public class EmployeeMetadata
    {
        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }


        public int? DirectReportID { get; set; }


        public int? DepartmentID { get; set; }

    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee { }

    #endregion

    #region Product Metadata
    public class ProductMetadata
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Product Name")]
        public string ProductName { get; set; }

        [Required]
        public int CategoryID { get; set; }

        
        public int? GenderID { get; set; }


        public int? StockStatusID { get; set; }


        public int? UnitsInStock { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [Required]
        public bool IsMensApperal { get; set; }

        [Required]
        public bool IsFemaleApperal { get; set; }

        [Required]
        public bool OtherApperal { get; set; }


        public string ProductImage { get; set; }

        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }

    #endregion


    #region Stock Status Metadata
    public class StockStatuMetadata
    {
        [Required]
        public int StockStatusID { get; set; }

        [Required]
        [StringLength(20)]
        public string StockStatus { get; set; }

    }

    [MetadataType(typeof(StockStatuMetadata))]
    public partial class StockStatu { }

    #endregion
}
