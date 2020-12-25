using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthWind_Handling.Models
{
    public class ProductViewModel
    {

 
   
        
            [Required(ErrorMessage = "must enter ya 3am")]

            public int ID { get; set; }

            [Required(ErrorMessage = "********")]
            [StringLength(40)]
            public string ProductName { get; set; }

            public int? SupplierID { get; set; }

            [Required(ErrorMessage = "********")]
            public bool Discontinued { get; set; }


        }



    }

