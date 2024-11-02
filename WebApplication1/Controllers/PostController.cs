using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Models;

public class PostsController : Controller
{
    private readonly AppDbContext _context;

    public PostsController(AppDbContext context)
    {
        _context = context;
    }

    // 게시글 목록 보기
    public async Task<IActionResult> Index()
    {
        var posts = await _context.Posts.ToListAsync();
        return View(posts);
    }

    // 게시글 상세 보기
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post == null) return NotFound();

        return View(post);
    }

    // 게시글 작성 페이지
    public IActionResult Create()
    {
        return View(); // Create.cshtml 뷰를 반환
    }

    // 게시글 작성 처리
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Post post)
    {
        if (ModelState.IsValid)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }

    // 게시글 수정 페이지
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var post = await _context.Posts.FindAsync(id);
        if (post == null) return NotFound();

        return View(post);
    }

    // 게시글 수정 처리
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Post post)
    {
        if (id != post.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(post);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Posts.Any(p => p.Id == post.Id))
                    return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }

    // 게시글 삭제
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post == null) return NotFound();

        return View(post);
    }

    // 게시글 삭제 처리
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
