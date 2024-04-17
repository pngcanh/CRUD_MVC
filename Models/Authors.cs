using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogMVC.Models
{
    public class AuthorsModle
    {
        [Key]
        public int AuthorID { set; get; }

        [Required(ErrorMessage = "Không được bỏ trống {0}!")]
        [Display(Name = "Tên tác giả")]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string AuthorName { set; get; }

        [Display(Name = "Giới tính")]
        [Column(TypeName = "bit")]
        public bool Gender { set; get; }

        [Display(Name = "Địa chỉ email")]
        [Column(TypeName = "Char")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

    }
}

