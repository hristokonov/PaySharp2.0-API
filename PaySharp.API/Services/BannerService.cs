using PaySharp.API.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySharp.API.Services
{
    public class BannerService : IBannerService
    {
        //private readonly PaySharpDBContext context;
        //private readonly IRandomGenerator randomGenerator;
        //private readonly IDtoMapper<Banner, BannerDTO> bannerMapper;
        //private readonly IDateWrapper dateWrapper;

        //public BannerService(PaySharpDBContext context, IRandomGenerator randomGenerator,
        //    IDtoMapper<Banner, BannerDTO> bannerMapper, IDateWrapper dateWrapper)
        //{
        //    this.context = context ?? throw new ArgumentNullException(nameof(context));
        //    this.randomGenerator = randomGenerator ?? throw new ArgumentNullException(nameof(randomGenerator));
        //    this.bannerMapper = bannerMapper ?? throw new ArgumentNullException(nameof(bannerMapper));
        //    this.dateWrapper = dateWrapper ?? throw new ArgumentNullException(nameof(dateWrapper));
        //}

        //public async Task<BannerDTO> CreateBanner(string name, string imgPath, string url, DateTime startDate, DateTime endDate)
        //{
        //    var banner = new Banner()
        //    {
        //        Name = name,
        //        ImgPath = imgPath,
        //        Url = url,
        //        StartDate = startDate,
        //        EndDate = endDate
        //    };

        //    context.Banners.Add(banner);
        //    await context.SaveChangesAsync();
        //    var bannerDTO = bannerMapper.MapFrom(banner);
        //    return bannerDTO;
        //}

        //public async Task<BannerDTO> GetBannerAsync()
        //{
        //    var date = dateWrapper.Now();
        //    var banners = await context.Banners.Where(b => b.StartDate <= date && b.EndDate >= date).ToListAsync();
        //    if (banners.Count == 0)
        //    {
        //        return null;
        //    }
        //    var randomNumber = int.Parse(randomGenerator.GenerateNumber(0, banners.Count - 1, 1));
        //    var banner = banners[randomNumber];
        //    var bannerDTO = bannerMapper.MapFrom(banner);
        //    return bannerDTO;
        //}

        //public async Task<BannerDTO> DeleteBanner(string id, string root)
        //{

        //    var banner = await context.Banners.SingleOrDefaultAsync(b => b.Id.ToString() == id);
        //    var filePath = Path.Combine(root, banner.ImgPath);
        //    System.IO.File.Delete(filePath);
        //    context.Banners.Remove(banner);
        //    await context.SaveChangesAsync();
        //    var bannerDTO = bannerMapper.MapFrom(banner);
        //    return bannerDTO;
        //}

        //public async Task<BannerDTO> EditBanner(string id, DateTime startDate, DateTime endDate)
        //{
        //    var banner = await context.Banners.SingleOrDefaultAsync(b => b.Id.ToString() == id);
        //    banner.StartDate = startDate;
        //    banner.EndDate = endDate;
        //    await context.SaveChangesAsync();
        //    var bannerDTO = bannerMapper.MapFrom(banner);
        //    return bannerDTO;
        //}

        //public async Task<IEnumerable<BannerDTO>> GetAllBannersAsync(int currentPage, int pageSize = 6)
        //{
        //    var banners = await context.Banners
        //        .OrderBy(b => b.Name)
        //         .OrderByDescending(c => c.Name)
        //         .Skip((currentPage - 1) * pageSize)
        //         .Take(pageSize)
        //         .Select(c => bannerMapper.MapFrom(c))
        //         .ToListAsync();

        //    return banners;
        //}

        //public async Task<long> GetCount()
        //{
        //    var banners = await context.Banners.CountAsync();

        //    return banners;
        //}
    }
}
