using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Added for metadata and validation

namespace ProjectName.DATA.EF//.ClimberClubMetadata
{
    #region Category Metadata
    public class CategoryMetadata
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

    #region MyRegion
    public class EmployeeMetadata
    {
        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }


        //public int? DirectReportID { get; set; }


        //public int? DepartmentID { get; set; }
    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee { }

    #endregion

    #region Department Metadata

    public class DepartmentMetadata
    {
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(20)]
        [UIHint("MultilineText")]
        public string Description { get; set; }
    }

    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department { }

    #endregion

    #region Product Metadata
    public class ProductMetadata
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [DisplayFormat(NullDisplayText = "Gender")]
        public int? GenderID { get; set; }

        [Display(Name = "Stock Status")]
        public int? StockStatusID { get; set; }

        [Display(Name = "Units In Stock")]
        public int? UnitsInStock { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Mens")]
        public bool IsMensApperal { get; set; }

        [Required]
        [Display(Name = "Womens")]
        public bool IsFemaleApperal { get; set; }

        [Required]
        [Display(Name = "Other")]
        public bool OtherApperal { get; set; }

        [Display(Name = "Image")]
        public string ProductImage { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; }
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }

    #endregion

    #region StockStatu Metadata
    public class StockStatuMetadata
    {
        [Required]
        public int StockStatusID { get; set; }

        [Required]
        public string StockStatus { get; set; }
    }

    [MetadataType(typeof(StockStatuMetadata))]
    public partial class StockStatu { }
    #endregion

}




