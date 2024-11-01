using Microsoft.EntityFrameworkCore;

// public class Startup
// {

//     private readonly IConfiguration _configuration;

//     private Startup(IConfiguration configuration)
//     {
//         _configuration = configuration;
//     }
//     public void ConfigureServices(IServiceCollection services)
//     {
//         // 데이터베이스 연결 설정
//         string connectionString = _configuration.GetConnectionString("DefaultConnection");

//         // AppDbContext를 DI 컨테이너에 등록
//         services.AddDbContext<AppDbContext>(options =>
//             options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//         // 다른 서비스 등록
//         services.AddControllersWithViews();
//     }

  
// }