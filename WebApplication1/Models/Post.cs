using System.ComponentModel.DataAnnotations;
using System.Data;
namespace WebApplication1.Models
{
public class Post
{
    [Key]
    public int Id { get; set; }


    [StringLength(100, ErrorMessage = "제목은 100자를 넘을 수 없습니다.")]
    public string Title { get; set; }


    public string Content { get; set; }

    public string Author {get; set;}


    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt {get; set;}
}
}