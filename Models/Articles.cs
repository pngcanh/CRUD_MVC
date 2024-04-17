using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogMVC.Models
{
    public class ArticlesModel
    {
        [Key]
        public int ArticleID { set; get; }

        [Required(ErrorMessage = "Không được bỏ trống {0}!")]
        [Display(Name = "Tiêu đề")]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Title { set; get; }

        [Display(Name = "Nội dung")]
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Không được bỏ trống {0}!")]
        public string Content { set; get; }

        [Display(Name = "Ngày tạo")]
        [Column(TypeName = "DateTime")]
        [Required(ErrorMessage = "Không được bỏ trống {0}!")]
        public DateTime Created { get; set; }

        // [Display(Name = "Thể loại")]
        // public int CateID { set; get; }
        [ForeignKey("CateID")]
        [Display(Name = "Thể loại")]
        public CategoriesModel CategoryID { set; get; }

        // [Display(Name = "Tác giả")]
        // public int AuID { set; get; }
        [ForeignKey("AuID")]
        [Display(Name = "Tác giả")]
        public AuthorsModle AuthorID { set; get; }
    }

}