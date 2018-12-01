using System.ComponentModel.DataAnnotations;
using Welfare.Models;

namespace Welfare.Areas.DropDownLists.Models
{
    public class GuardianType : TableBase
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
    }
}
