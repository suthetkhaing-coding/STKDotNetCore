using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace STKDotNetCore.RestApiWithNLayer.Features.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<Tbl_MmProverbs> GetDataAsync()
        {
            //HttpClient client = new HttpClient();
            //var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
            //if (!response.IsSuccessStatusCode) return null;

            //string jsonStr = await response.Content.ReadAsStringAsync();
            //var model = JsonConvert.DeserializeObject<Tbl_MmProverbs>(jsonStr);
            //return model!;

            string jsonStr = await System.IO.File.ReadAllTextAsync("data2.json");
            var model = JsonConvert.DeserializeObject<Tbl_MmProverbs>(jsonStr);
            return model!;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("{titleName}")]
        public async Task<IActionResult> Get(string titleName)
        {
            var model = await GetDataAsync();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null)
                return NotFound("No title name found.");

            var titleId = item.TitleId;
            //var lst = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId).ToList();
            //return Ok(lst);
            var result = model.Tbl_MMProverbs.Where(X => X.TitleId == titleId);
            
            List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
            {
                ProverbId = x.ProverbId,
                ProverbName = x.ProverbName,
                TitleId = x.TitleId
            }).ToList();

            return Ok(lst);
        }

        [HttpGet("{titleId}/{proverbId}")]
        public async Task<IActionResult> Get(int titleId, int proverbId)
        {
            var model = await GetDataAsync();
            var proverb = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);

            if (proverb is null)
            {
                return NotFound("No proverb found.");
            }

            return Ok(proverb);
        }
    }

    public class Tbl_MmProverbs
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_MmproverbsDetail[] Tbl_MMProverbs { get; set; }
    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_MmproverbsDetail
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }

    public class Tbl_MmproverbsHead
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
    }
}
